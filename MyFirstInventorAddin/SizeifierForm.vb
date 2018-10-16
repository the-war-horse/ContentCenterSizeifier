Imports System.Windows.Forms
Imports Inventor
Imports ContentCenterSizeifier.ContentCenterSizeifier
Imports log4net

Public Class SizeifierForm
    'Inherits Form
    Private inventorApp As Inventor.Application
    Private DocaWindow As DockableWindow
    Private value As String
    Public Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)

    Public Sub New(ByVal inventorApp As Inventor.Application, ByVal addinCLS As String, ByRef localWindow As DockableWindow)

        InitializeComponent()

        'Me.KeyPreview = True
        'Me.inventorApp = inventorApp
        'Me.value = addinCLS
        'Me.DocaWindow = localWindow
        'Dim uiMgr As UserInterfaceManager = inventorApp.UserInterfaceManager
        '    Dim addinName As String = lbAddinName.Text
        'Dim SizeifierWindow As DockableWindow = uiMgr.DockableWindows.Add(addinCLS, "ContentCenterSizeifierWindow", "Content Center Sizeifier " + addinName)
        'SizeifierWindow.AddChild(Me.Handle)

        'If Not SizeifierWindow.IsCustomized = True Then
        '    'SizeifierWindow.DockingState = DockingStateEnum.kFloat
        '    SizeifierWindow.DockingState = DockingStateEnum.kDockLastKnown
        'Else
        '    SizeifierWindow.DockingState = DockingStateEnum.kFloat
        'End If
        'SizeifierWindow.ShowVisibilityCheckBox = True
        'SizeifierWindow.ShowTitleBar = True
        'SizeifierWindow.SetMinimumSize(100, 100)
        'SizeifierWindow.Visible = True
        'SizeifierWindow.DisabledDockingStates = DockingStateEnum.kDockTop + DockingStateEnum.kDockBottom

        ''Me.Dock = DockStyle.Fill
        'Me.Visible = True
        'localWindow = SizeifierWindow
        'AddinGlobal.DockableList.Add(SizeifierWindow)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSizes.SelectedIndexChanged

    End Sub

    'Public Shared Function GetFileName(path As String) As String
    'End Function
End Class
