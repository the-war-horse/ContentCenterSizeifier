Imports System.Windows.Forms
Imports Inventor
Imports ContentCenterSizeifier.ContentCenterSizeifier
Imports System.Linq

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
        'Throw New NotImplementedException
    End Sub

    Private Sub cbbLength_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbLength.SelectedIndexChanged
        If Not AddinGlobal.family Is Nothing Then
            Me.ListSizes.DataSource = (From desigRow As ContentTableRow In AddinGlobal.family.TableRows
                                       Let designation As String = desigRow.GetCellValue("DESIGNATION")
                                       Where designation.EndsWith(cbbLength.SelectedItem.ToString)
                                       Select designation).Distinct.ToList()
        End If
    End Sub

    Private Sub cbbDiameter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbDiameter.SelectedIndexChanged
        If Not AddinGlobal.family Is Nothing Then
            ListSizes.DataSource = (From diameterRow As ContentTableRow In AddinGlobal.family.TableRows
                                    Let diameter As String = diameterRow.GetCellValue("SIZE_SEL")
                                    Where diameter.Contains(cbbDiameter.SelectedItem.ToString()) And diameter.Contains(cbbLength.SelectedItem.ToString())
                                    Select diameter).Distinct.ToList()
        End If
        'Throw New NotImplementedException
    End Sub

    Private Sub cbbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbMaterial.SelectedIndexChanged
        'Throw New NotImplementedException
    End Sub

    'Public Shared Function GetFileName(path As String) As String
    'End Function
End Class
