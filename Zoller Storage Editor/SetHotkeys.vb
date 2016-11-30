Imports System.Windows.Forms

Public Class SetHotkeys
  Private _lst As ListBox
  Private _kv As New SortedList(Of String, String)

  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    _lst = lstF9
    _kv = New SortedList(Of String, String)
    For Each k As String In My.Resources.HotKeyValuePair.Split({vbLf}, StringSplitOptions.RemoveEmptyEntries)
      _kv.Add(k.Remove(k.IndexOf("=")), k.Remove(0, k.IndexOf("=") + 1))
    Next

  End Sub
  Private Sub SetHotkeys_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim arr As String()
    If Not IsNothing(My.Settings.F9Keys) Then
      ReDim arr(My.Settings.F9Keys.Count)
      My.Settings.F9Keys.CopyTo(arr, 0)
      CleanArray(arr)
      lstF9.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F10Keys) Then
      ReDim arr(My.Settings.F10Keys.Count)
      My.Settings.F10Keys.CopyTo(arr, 0)
      CleanArray(arr)
      lstF10.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F11Keys) Then
      ReDim arr(My.Settings.F11Keys.Count)
      My.Settings.F11Keys.CopyTo(arr, 0)
      CleanArray(arr)
      lstF11.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F12Keys) Then
      ReDim arr(My.Settings.F12Keys.Count)
      My.Settings.F12Keys.CopyTo(arr, 0)
      CleanArray(arr)
      lstF12.Items.AddRange(arr)
    End If
  End Sub
  Private Sub CleanArray(ByRef Arr As String())
    Dim lst As New List(Of String)
    For i = 0 To Arr.Length - 1 Step 1
      If Arr(i) IsNot Nothing Then
        lst.Add(Arr(i))
      Else
        Debug.WriteLine("Is Nothing")
      End If
    Next
    Arr = lst.ToArray()
  End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
  End Sub

  Private Sub tabHotkeys_Click(sender As Object, e As EventArgs) Handles tabHotkeys.Click
    Select Case tabHotkeys.SelectedTab.Text
      Case "F9"
        _lst = lstF9
      Case "F10"
        _lst = lstF10
      Case "F11"
        _lst = lstF11
      Case "F12"
        _lst = lstF12
      Case Else
        _lst = Nothing
    End Select
  End Sub

  Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    If Not IsNothing(_lst) Then
      If Not IsNothing(drpKeys.SelectedItem) Then
        Dim blnLastKeyHasHold As Boolean = False
        Dim strKey As String = _kv(drpKeys.SelectedItem.ToString)
        If chkHoldCtrl.Checked Then strKey = AddHold("^", strKey)
        If chkHoldShift.Checked Then strKey = AddHold("+", strKey)
        If chkHoldAlt.Checked Then strKey = AddHold("%", strKey)
        _lst.Items.Add(strKey)
        UpdateHotkeys()
      Else
        Debug.WriteLine("no keys selected")
      End If
    Else
      Debug.WriteLine("list is nothing")
    End If
  End Sub
  Private Function AddHold(ByVal HoldChar As Char, ByVal Input As String) As String
    'If Input.Contains("{") And (Input.Contains("^") Or Input.Contains("+") Or Input.Contains("%")) And Not Input.Contains(HoldChar) Then
    '  Input = Input.Replace("{", HoldChar & "{")
    'ElseIf Input.Contains(HoldChar) Then
    '  ' Do nothing
    '  'return Input
    'Else
    '  Input = HoldChar & "{" & Input & "}"
    'End If

    'If Input.Contains("(") And (Input.Contains("^") Or Input.Contains("+") Or Input.Contains("%")) And Not Input.Contains(HoldChar) Then
    '  Input = Input.Replace("(", HoldChar & "(")
    'ElseIf Input.Contains(HoldChar) Then
    '  ' Do nothing
    '  'return Input
    'Else
    '  Input = HoldChar & "(" & Input & ")"
    'End If

    If (Input.Contains("^") Or Input.Contains("+") Or Input.Contains("%")) And Not Input.Contains(HoldChar) Then
      Input = Input.Insert(1, HoldChar)
    ElseIf Input.Contains(HoldChar) Then
      ' Do nothing
      'return Input
    Else
      Input = HoldChar & Input
    End If
    Return Input
  End Function
  Private Sub btnAddApp_Click(sender As Object, e As EventArgs) Handles btnAddApp.Click
    If Not IsNothing(_lst) Then
      _lst.Items.Add("{APPHOLD}")
      UpdateHotkeys()
    Else
      Debug.WriteLine("list is nothing")
    End If
  End Sub

  Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
    If Not IsNothing(_lst) Then
      If Not IsNothing(_lst.SelectedItem) Then
        _lst.Items.RemoveAt(_lst.SelectedIndex)
        UpdateHotkeys()
      Else
        Debug.WriteLine("no item selected")
      End If
    Else
      Debug.WriteLine("list is nothing")
    End If
  End Sub
  Private Sub btnClearList_Click(sender As Object, e As EventArgs) Handles btnClearList.Click
    If Not IsNothing(_lst) Then
      _lst.Items.Clear()
      UpdateHotkeys()
    End If
  End Sub

  Private Sub UpdateHotkeys()
    UpdateHotKey(lstF9, My.Settings.F9Keys)
    UpdateHotKey(lstF10, My.Settings.F10Keys)
    UpdateHotKey(lstF11, My.Settings.F11Keys)
    UpdateHotKey(lstF12, My.Settings.F12Keys)

    My.Settings.Save()
  End Sub
  Private Sub UpdateHotKey(ByVal lst As ListBox, ByVal sett As Specialized.StringCollection)
    If sett Is Nothing Then sett = New Specialized.StringCollection
    sett.Clear()
    If lst.Items.Count > 0 Then
      For Each it In lst.Items
        sett.Add(it.ToString.Replace(vbLf, Nothing))
      Next
    End If
  End Sub
End Class
