Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Linq
'Imports System.Windows.Forms
Imports Inventor

Namespace ContentCenterSizeifier

    <ProgIdAttribute("ContentCenterSizeifier.StandardAddInServer"),
    GuidAttribute("0A36F323-0005-408D-8049-2B40A4E9690A")>
    Public Class SizeifierAddInServer
        Implements Inventor.ApplicationAddInServer

        'some events objects we might need later
        Private WithEvents m_uiEvents As UserInterfaceEvents

        Private WithEvents m_UserInputEvents As UserInputEvents
        Private WithEvents m_AppEvents As ApplicationEvents

        ' new unused - at this point - event objects
        Private WithEvents m_DocEvents As DocumentEvents

        Private WithEvents m_AssemblyEvents As AssemblyEvents
        Private WithEvents m_PartEvents As PartEvents
        Private WithEvents m_ModelingEvents As ModelingEvents
        Private WithEvents m_StyleEvents As StyleEvents

        Private thisAssembly As Assembly = Assembly.GetExecutingAssembly()
        Private thisAssemblyPath As String = String.Empty
        Public Shared attribute As GuidAttribute = Nothing
        Public Shared SizeifierForm As SizeifierForm = Nothing 'System.Windows.Forms.Form = Nothing '
        Public Property InventorAppQuitting As Boolean = False

        'Private WithEvents m_sampleButton As ButtonDefinition

#Region "ApplicationAddInServer Members"

        ' This method is called by Inventor when it loads the AddIn. The AddInSiteObject provides access
        ' to the Inventor Application object. The FirstTime flag indicates if the AddIn is loaded for
        ' the first time. However, with the introduction of the ribbon this argument is always true.
        Public Sub Activate(ByVal addInSiteObject As ApplicationAddInSite, ByVal firstTime As Boolean) Implements ApplicationAddInServer.Activate
            ' Initialize AddIn members.
            AddinGlobal.InventorApp = addInSiteObject.Application
            attribute = DirectCast(thisAssembly.GetCustomAttributes(GetType(GuidAttribute), True)(0), GuidAttribute)

            AddinGlobal.GetAddinClassId(Me.GetType())
            'store our Addin path.
            thisAssemblyPath = IO.Path.GetDirectoryName(thisAssembly.Location)
            ' Connect to the user-interface events to handle a ribbon reset.
            m_uiEvents = AddinGlobal.InventorApp.UserInterfaceManager.UserInterfaceEvents
            'Connect to the Application Events to handle document opening/switching for our iProperties dockable Window.
            m_AppEvents = AddinGlobal.InventorApp.ApplicationEvents
            m_UserInputEvents = AddinGlobal.InventorApp.CommandManager.UserInputEvents
            m_StyleEvents = AddinGlobal.InventorApp.StyleEvents

            AddHandler m_AppEvents.OnQuit, AddressOf Me.m_ApplicationEvents_OnQuit
            AddHandler m_AppEvents.OnActivateDocument, AddressOf Me.m_applicationEvents_OnActivateDocument
            AddHandler m_UserInputEvents.OnActivateCommand, AddressOf Me.m_UserInputEvents_OnActivateCommand

            'you can add extra handlers like this - if you uncomment the next line Visual Studio will prompt you to create the method:
            'AddHandler m_AssemblyEvents.OnNewOccurrence, AddressOf Me.m_AssemblyEvents_NewOcccurrence
            If Not AddinGlobal.InventorApp.ActiveDocument Is Nothing Then
                m_DocEvents = AddinGlobal.InventorApp.ActiveDocument.DocumentEvents
                AddHandler m_DocEvents.OnChangeSelectSet, AddressOf Me.m_DocumentEvents_OnChangeSelectSet
            End If

            ' TODO: Add button definitions.

            ' Sample to illustrate creating a button definition.
            'Dim largeIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.YourBigImage)
            'Dim smallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.YourSmallImage)
            'Dim controlDefs As Inventor.ControlDefinitions = g_inventorApplication.CommandManager.ControlDefinitions
            'm_sampleButton = controlDefs.AddButtonDefinition("Command Name", "Internal Name", CommandTypesEnum.kShapeEditCmdType, AddInClientID)

            'Dim icon1 As New Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("ContentCenterSizeifier.addin.ico"))
            'Change it if necessary but make sure it's embedded.
            Dim button2 As New SizeifierButton("Button 2", "Sizeifier.Button_" & Guid.NewGuid().ToString(), "Button 2 description", "Button 1 tooltip",
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode)
            button2.SetBehavior(True, True, True)
            button2.Execute = AddressOf ButtonActions.Button1_Execute

            ' Add to the user interface, if it's the first time.
            If firstTime Then
                AddToUserInterface(button2)
                'add our userform to a new DockableWindow
                'Dim SizeifierWindow As DockableWindow = Nothing
                Dim uiMgr As UserInterfaceManager = AddinGlobal.InventorApp.UserInterfaceManager
                Dim SizeifierWindow As DockableWindow = uiMgr.DockableWindows.Add(Guid.NewGuid().ToString(),
                                                                                  "ContentCenterSizeifierWindow",
                                                                                  "Content Center Sizeifier " + "v1.0.0")
                SizeifierForm = New SizeifierForm(AddinGlobal.InventorApp, attribute.Value, SizeifierWindow)

                SizeifierWindow.AddChild(SizeifierForm.Handle)

                If Not SizeifierWindow.IsCustomized = True Then
                    'SizeifierWindow.DockingState = DockingStateEnum.kFloat
                    SizeifierWindow.DockingState = DockingStateEnum.kDockLastKnown
                Else
                    SizeifierWindow.DockingState = DockingStateEnum.kFloat
                End If
                SizeifierWindow.ShowVisibilityCheckBox = True
                SizeifierWindow.ShowTitleBar = True
                SizeifierWindow.SetMinimumSize(100, 100)
                SizeifierWindow.Visible = True
                SizeifierWindow.DisabledDockingStates = DockingStateEnum.kDockTop + DockingStateEnum.kDockBottom

                'Me.Dock = DockStyle.Fill
                SizeifierForm.Visible = True
                'localWindow = SizeifierWindow
                AddinGlobal.DockableList.Add(SizeifierWindow)
                'Window = SizeifierWindow

            End If
        End Sub

        Private Sub m_applicationEvents_OnActivateDocument(DocumentObject As _Document, BeforeOrAfter As EventTimingEnum, Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
            If BeforeOrAfter = EventTimingEnum.kAfter Then
                m_DocEvents = DocumentObject.DocumentEvents
                AddHandler m_DocEvents.OnChangeSelectSet, AddressOf Me.m_DocumentEvents_OnChangeSelectSet
            End If
        End Sub

        Public Shared Sub UpdateStatusBar(ByVal Message As String)
            AddinGlobal.InventorApp.StatusBarText = Message
        End Sub

        Private Sub m_UserInputEvents_OnActivateCommand(CommandName As String, Context As NameValueMap)
            If Not AddinGlobal.InventorApp.ActiveDocument Is Nothing Then
                If (AddinGlobal.InventorApp.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject) Then
                    If CommandName = "CCV2ChangeSizeButton" Or CommandName = "CCV2ChangeSizeButton" Then
                        DocumentToPulliPropValuesFrom = AddinGlobal.InventorApp.ActiveDocument

                    End If
                End If
            End If
        End Sub

        Private _inChangeSelectSetHandler As Boolean = False

        ''' <summary>
        ''' This method is what helps us capture properties from selected items.
        ''' It works fine in Parts and Drawings, but not currently Assemblies.
        ''' </summary>
        ''' <param name="BeforeOrAfter"></param>
        ''' <param name="Context"></param>
        ''' <param name="HandlingCode"></param>
        Private Sub m_DocumentEvents_OnChangeSelectSet(BeforeOrAfter As EventTimingEnum, Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
            HandlingCode = HandlingCodeEnum.kEventNotHandled
            If BeforeOrAfter = EventTimingEnum.kAfter Then
                If _inChangeSelectSetHandler Then
                    ' We have probably caused this by changing the select set within the handler.
                    ' Avoid recursion by returning early.
                    _inChangeSelectSetHandler = False
                    Return
                End If

                _inChangeSelectSetHandler = True
                Try
                    If Not AddinGlobal.InventorApp.ActiveDocument Is Nothing Then

                        If (AddinGlobal.InventorApp.ActiveEditDocument.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject) Then
                            Dim AssyDoc As AssemblyDocument = AddinGlobal.InventorApp.ActiveDocument
                            If AssyDoc.SelectSet.Count = 1 Then
                                If TypeOf AssyDoc.SelectSet(1) Is ComponentOccurrence Then
                                    Dim compOcc As ComponentOccurrence = AssyDoc.SelectSet(1)
                                    'Dim oDoc As Document = AssyDoc.SelectSet(1)
                                    If TypeOf compOcc.Definition.Document Is PartDocument Then
                                        Dim oDoc As Document = compOcc.Definition.Document
                                        If oDoc.FullFileName.Contains("Content Center") Then
                                            Dim thisPartDoc As PartDocument = compOcc.Definition.Document
                                            SizeifierForm.tbCurrentPart.Text = iProperties.GetorSetStandardiProperty(oDoc, PropertiesForDesignTrackingPropertiesEnum.kDescriptionDesignTrackingProperties, "", "")
                                            Dim family As ContentFamily = Nothing
                                            Dim memberRow As ContentTableRow = Nothing
                                            Dim sizeCol As ContentTableColumn = Nothing
                                            Dim materialCol As ContentTableColumn = Nothing
                                            Dim memberRowStr As String = String.Empty

                                            GetContentCentreProperties(thisPartDoc, AddinGlobal.family,
                                                                       AddinGlobal.memberRow,
                                                                       AddinGlobal.sizeCol,
                                                                       AddinGlobal.materialCol)
                                            'memberRow = (From row As ContentTableRow In family.TableRows
                                            '             Where row.InternalName = memberRowStr
                                            '             Select row).FirstOrDefault()
                                            SizeifierForm.cbbDesignation.DataSource = (From desigRow As ContentTableRow In AddinGlobal.family.TableRows
                                                                                       Let designation As String = desigRow.GetCellValue("DESIGNATION")
                                                                                       Select designation).Distinct.ToList()
                                            SizeifierForm.cbbLength.DataSource = (From sizeRows As ContentTableRow In AddinGlobal.family.TableRows
                                                                                  Let size As String = sizeRows.GetCellValue(AddinGlobal.sizeCol)
                                                                                  Select size).Distinct.ToList()
                                            SizeifierForm.cbbMaterial.DataSource = (From materialRow As ContentTableRow In AddinGlobal.family.TableRows
                                                                                    Let material As String = materialRow.GetCellValue(AddinGlobal.materialCol)
                                                                                    Select material).Distinct.ToList()

                                            AddinGlobal.diaCol = family.TableColumns("SIZE_SEL")
                                            SizeifierForm.cbbDiameter.DataSource = (From diamRow As ContentTableRow In AddinGlobal.family.TableRows
                                                                                    Let diam As String = diamRow.GetCellValue(AddinGlobal.diaCol)
                                                                                    Select diam).Distinct.ToList()

                                            SizeifierForm.ListSizes.DataSource = (From desigRow As ContentTableRow In AddinGlobal.family.TableRows
                                                                                  Let designation As String = desigRow.GetCellValue("DESIGNATION")
                                                                                  Select designation).Distinct.ToList()
                                            'If Not memberRowStr Is String.Empty Then
                                            '    SizeifierForm.cbbDesignation.Text = memberRowStr
                                            'End If
                                            SizeifierForm.ListSizes = Nothing

                                        Else
                                            SizeifierForm.tbCurrentPart.Text = String.Empty
                                        End If
                                    Else
                                        SizeifierForm.tbCurrentPart.Text = String.Empty
                                    End If
                                Else
                                    SizeifierForm.tbCurrentPart.Text = String.Empty
                                End If
                            Else
                                SizeifierForm.tbCurrentPart.Text = String.Empty
                            End If

                        End If
                        'End If
                    End If
                Finally
                    _inChangeSelectSetHandler = False
                End Try
            End If
        End Sub

        ''' <summary>
        ''' Gets the necessary CC-specifics to allow us to query the CC and get the rest of the relevant rows.
        ''' </summary>
        ''' <param name="partDoc"></param>
        ''' <param name="ccFamily"></param>
        ''' <param name="ccMemberRow"></param>
        Private Sub GetContentCentreProperties(ByVal partDoc As PartDocument,
                                               ByRef ccFamily As ContentFamily,
                                               ByRef ccMemberRow As ContentTableRow,
                                               ByRef ccSizeCol As ContentTableColumn,
                                               ByRef ccMaterialCol As ContentTableColumn)
            Dim ContentCentre As ContentCenter = AddinGlobal.InventorApp.ContentCenter
            Dim partCompDef As PartComponentDefinition = partDoc.ComponentDefinition
            Dim ccMemberRowStr As String = String.Empty
            If partCompDef.IsContentMember Then
                ccFamily = ContentCentre.GetContentObject("v3#" + iProperties.GetorSetStandardiProperty(partDoc, PropertiesForContentLibraryEnum.kFamilyIdContentLibrary) + "#")
                ccMemberRowStr = iProperties.GetorSetStandardiProperty(partDoc, PropertiesForContentLibraryEnum.kMemberIdContentLibrary)
                ccMemberRow = (From row As ContentTableRow In ccFamily.TableRows
                               Where row.InternalName = ccMemberRowStr
                               Select row).FirstOrDefault()
                ccSizeCol = ccFamily.TableColumns("NLG") '("SIZE")
                ccMaterialCol = ccFamily.TableColumns("MATERIAL_ALIAS")
                'ccMemberRow = ContentCentre.GetContentObject("v3#" + iProperties.GetorSetStandardiProperty(partDoc, PropertiesForContentLibraryEnum.kMemberIdContentLibrary))
            Else
                Throw New NotImplementedException("We haven't designed this tool for working with custom Content Centre parts yet, sorry!")
            End If
        End Sub


        Private Sub m_ApplicationEvents_OnQuit(BeforeOrAfter As EventTimingEnum, Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
            If BeforeOrAfter = EventTimingEnum.kBefore Then
                InventorAppQuitting = True
            End If
        End Sub

        ''' <summary>
        ''' Original copied verbatim from here:
        ''' http://adndevblog.typepad.com/manufacturing/2012/05/checking-whether-a-inventor-document-is-read-only-or-not.html
        ''' Modified as suggested by this page:
        ''' https://msdn.microsoft.com/en-us/library/system.io.fileattributes(v=vs.110).aspx?f=255&MSPPError=-2147217396&cs-save-lang=1&cs-lang=vb#code-snippet-2
        ''' </summary>
        ''' <param name="doc"></param>
        ''' <returns></returns>
        Public Shared Function CheckReadOnly(ByVal doc As Document) As Boolean
            ' Handle the case with the active document never saved
            If System.IO.File.Exists(doc.FullFileName) = False Then
                UpdateStatusBar("Save file before executing this method. Exiting ...")
                Return False
            End If

            Dim atts As FileAttributes = IO.File.GetAttributes(doc.FullFileName)

            If ((atts And FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly) Then
                Return True
            Else
                'The file is Read/Write
                Return False
            End If

        End Function

        ' This method is called by Inventor when the AddIn is unloaded. The AddIn will be
        ' unloaded either manually by the user or when the Inventor session is terminated.
        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate
            ' TODO:  Add ApplicationAddInServer.Deactivate implementation
            For Each item As SizeifierButton In AddinGlobal.ButtonList
                Marshal.FinalReleaseComObject(item.ButtonDef)
            Next

            For Each item As DockableWindow In AddinGlobal.DockableList
                Marshal.FinalReleaseComObject(item)
            Next

            ' Release objects.

            m_UserInputEvents = Nothing
            m_AppEvents = Nothing
            m_uiEvents = Nothing
            m_StyleEvents = Nothing

            thisAssembly = Nothing
            SizeifierForm = Nothing

            If AddinGlobal.RibbonPanel IsNot Nothing Then
                Marshal.FinalReleaseComObject(AddinGlobal.RibbonPanel)
            End If

            If Not InventorAppQuitting Then
                If AddinGlobal.InventorApp IsNot Nothing Then
                    Marshal.FinalReleaseComObject(AddinGlobal.InventorApp)
                End If
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()

        End Sub

        ' This property is provided to allow the AddIn to expose an API of its own to other
        ' programs. Typically, this  would be done by implementing the AddIn's API
        ' interface in a class and returning that class object through this property.
        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation
            Get
                Return Nothing
            End Get
        End Property

        Private m_thisWindow As DockableWindow

        Public Property Window() As DockableWindow
            Get
                Return m_thisWindow
            End Get
            Set(ByVal value As DockableWindow)
                m_thisWindow = value
            End Set
        End Property

        'Public Property Window As DockableWindow
        '    Get
        '        Return
        '    End Get
        '    Set(value As DockableWindow)

        '    End Set
        'End Property

        ' Note:this method is now obsolete, you should use the
        ' ControlDefinition functionality for implementing commands.
        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand
        End Sub

#End Region

#Region "User interface definition"

        ' Sub where the user-interface creation is done.  This is called when
        ' the add-in loaded and also if the user interface is reset.
        Private Sub AddToUserInterface(button2 As SizeifierButton)
            ' This is where you'll add code to add buttons to the ribbon.

            '** Sample to illustrate creating a button on a new panel of the Tools tab of the Part ribbon.

            '' Get the part ribbon.
            'Dim partRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Part")

            '' Get the "Tools" tab.
            'Dim toolsTab As RibbonTab = partRibbon.RibbonTabs.Item("id_TabTools")

            '' Create a new panel.
            'Dim customPanel As RibbonPanel = toolsTab.RibbonPanels.Add("Sample", "MysSample", AddInClientID)

            '' Add a button.
            'customPanel.CommandControls.AddButton(m_sampleButton)
            Dim uiMan As UserInterfaceManager = AddinGlobal.InventorApp.UserInterfaceManager
            If uiMan.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
                'kClassicInterface support can be added if necessary.
                Dim ribbon As Inventor.Ribbon = uiMan.Ribbons("Part")
                Dim tab As RibbonTab
                Try
                    tab = ribbon.RibbonTabs("id_TabSheetMetal") 'Change it if necessary.
                Catch
                    tab = ribbon.RibbonTabs.Add("id_TabSheetMetal", "id_Tabid_TabSheetMetal", Guid.NewGuid().ToString())
                End Try
                AddinGlobal.RibbonPanelId = "{0A36F323-0005-408D-8049-2B40A4E9690A}"
                AddinGlobal.RibbonPanel = tab.RibbonPanels.Add("SizeifierAddin", "SizeifierAddin.RibbonPanel_" & Guid.NewGuid().ToString(), AddinGlobal.RibbonPanelId, String.Empty, True)

                Dim cmdCtrls As CommandControls = AddinGlobal.RibbonPanel.CommandControls
                cmdCtrls.AddButton(button2.ButtonDef, button2.DisplayBigIcon, button2.DisplayText, "", button2.InsertBeforeTarget)
            End If
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        'no need for this since we can just restart Inventor and have it reload the addin.
        'Private Sub m_uiEvents_OnResetRibbonInterface(Context As NameValueMap) Handles m_uiEvents.OnResetRibbonInterface
        '    ' The ribbon was reset, so add back the add-ins user-interface.
        '    AddToUserInterface()
        'End Sub

        ' Sample handler for the button.
        'Private Sub m_sampleButton_OnExecute(Context As NameValueMap) Handles m_sampleButton.OnExecute
        '    MsgBox("Button was clicked.")
        'End Sub

#End Region

    End Class

End Namespace

Public Module Globals

    ' Inventor application object.
    Public g_inventorApplication As Inventor.Application

#Region "Function to get the add-in client ID."

    ' This function uses reflection to get the GuidAttribute associated with the add-in.
    Public Function AddInClientID() As String
        Dim guid As String = ""
        Try
            Dim t As Type = GetType(ContentCenterSizeifier.SizeifierAddInServer)
            Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
            Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
            guid = "{" + guidAttribute.Value.ToString() + "}"
        Catch
        End Try

        Return guid
    End Function

#End Region

#Region "hWnd Wrapper Class"

    ' This class is used to wrap a Win32 hWnd as a .Net IWind32Window class.
    ' This is primarily used for parenting a dialog to the Inventor window.
    '
    ' For example:
    ' myForm.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))
    '
    Public Class WindowWrapper
        Implements System.Windows.Forms.IWin32Window

        Public Sub New(ByVal handle As IntPtr)
            _hwnd = handle
        End Sub

        Public ReadOnly Property Handle() As IntPtr _
          Implements System.Windows.Forms.IWin32Window.Handle
            Get
                Return _hwnd
            End Get
        End Property

        Private _hwnd As IntPtr
    End Class

#End Region

#Region "Image Converter"

    ' Class used to convert bitmaps and icons from their .Net native types into
    ' an IPictureDisp object which is what the Inventor API requires. A typical
    ' usage is shown below where MyIcon is a bitmap or icon that's available
    ' as a resource of the project.
    '
    ' Dim smallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.MyIcon)

    Public NotInheritable Class PictureDispConverter

        <DllImport("OleAut32.dll", EntryPoint:="OleCreatePictureIndirect", ExactSpelling:=True, PreserveSig:=False)>
        Private Shared Function OleCreatePictureIndirect(
            <MarshalAs(UnmanagedType.AsAny)> ByVal picdesc As Object,
            ByRef iid As Guid,
            <MarshalAs(UnmanagedType.Bool)> ByVal fOwn As Boolean) As stdole.IPictureDisp
        End Function

        Shared iPictureDispGuid As Guid = GetType(stdole.IPictureDisp).GUID

        Private NotInheritable Class PICTDESC

            Private Sub New()
            End Sub

            'Picture Types
            Public Const PICTYPE_BITMAP As Short = 1

            Public Const PICTYPE_ICON As Short = 3

            <StructLayout(LayoutKind.Sequential)>
            Public Class Icon
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
                Friend picType As Integer = PICTDESC.PICTYPE_ICON
                Friend hicon As IntPtr = IntPtr.Zero
                Friend unused1 As Integer
                Friend unused2 As Integer

                Friend Sub New(ByVal icon As System.Drawing.Icon)
                    Me.hicon = icon.ToBitmap().GetHicon()
                End Sub

            End Class

            <StructLayout(LayoutKind.Sequential)>
            Public Class Bitmap
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
                Friend picType As Integer = PICTDESC.PICTYPE_BITMAP
                Friend hbitmap As IntPtr = IntPtr.Zero
                Friend hpal As IntPtr = IntPtr.Zero
                Friend unused As Integer

                Friend Sub New(ByVal bitmap As System.Drawing.Bitmap)
                    Me.hbitmap = bitmap.GetHbitmap()
                End Sub

            End Class

        End Class

        Public Shared Function ToIPictureDisp(ByVal icon As System.Drawing.Icon) As stdole.IPictureDisp
            Dim pictIcon As New PICTDESC.Icon(icon)
            Return OleCreatePictureIndirect(pictIcon, iPictureDispGuid, True)
        End Function

        Public Shared Function ToIPictureDisp(ByVal bmp As System.Drawing.Bitmap) As stdole.IPictureDisp
            Dim pictBmp As New PICTDESC.Bitmap(bmp)
            Return OleCreatePictureIndirect(pictBmp, iPictureDispGuid, True)
        End Function

    End Class

#End Region

End Module