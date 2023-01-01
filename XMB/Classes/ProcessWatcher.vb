Imports System
Imports System.ComponentModel
Imports System.Management
Imports System.Collections
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class ProcessWatcher
    Inherits ManagementEventWatcher

    Public Delegate Sub ProcessEventHandler(ByVal proc As Win32_Process)

    ' Process Events
    Public Event ProcessCreated As ProcessEventHandler
    Public Event ProcessDeleted As ProcessEventHandler
    Public Event ProcessModified As ProcessEventHandler

    ' WMI WQL process query strings
    Shared ReadOnly WMI_OPER_EVENT_QUERY As String = "SELECT * FROM " & vbCr & vbLf & "__InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'"
    Shared ReadOnly WMI_OPER_EVENT_QUERY_WITH_PROC As String = WMI_OPER_EVENT_QUERY + " and TargetInstance.Name = '{0}'"

    Public Sub New()
        Init(String.Empty)
    End Sub

    Public Sub New(ByVal processName As String)
        Init(processName)
    End Sub

    Private Sub Init(ByVal processName As String)
        Me.Query.QueryLanguage = "WQL"
        If String.IsNullOrEmpty(processName) Then
            Me.Query.QueryString = WMI_OPER_EVENT_QUERY
        Else
            Me.Query.QueryString = String.Format(WMI_OPER_EVENT_QUERY_WITH_PROC, processName)
        End If

        AddHandler Me.EventArrived, AddressOf watcher_EventArrived
    End Sub

    Private Sub watcher_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs)
        Dim eventType As String = e.NewEvent.ClassPath.ClassName
        Dim proc As New Win32_Process(TryCast(e.NewEvent("TargetInstance"), ManagementBaseObject))

        Select Case eventType
            Case "__InstanceCreationEvent"
                RaiseEvent ProcessCreated(proc)
                Exit Select
            Case "__InstanceDeletionEvent"
                RaiseEvent ProcessDeleted(proc)
                Exit Select
            Case "__InstanceModificationEvent"
                RaiseEvent ProcessModified(proc)
                Exit Select
        End Select
    End Sub

End Class