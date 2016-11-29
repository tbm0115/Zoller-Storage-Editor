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
      lstF9.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F10Keys) Then
      ReDim arr(My.Settings.F10Keys.Count)
      My.Settings.F10Keys.CopyTo(arr, 0)
      lstF10.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F11Keys) Then
      ReDim arr(My.Settings.F11Keys.Count)
      My.Settings.F11Keys.CopyTo(arr, 0)
      lstF11.Items.AddRange(arr)
    End If
    If Not IsNothing(My.Settings.F12Keys) Then
      ReDim arr(My.Settings.F12Keys.Count)
      My.Settings.F12Keys.CopyTo(arr, 0)
      lstF12.Items.AddRange(arr)
    End If
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
    If Input.Contains("(") And (Input.Contains("^") Or Input.Contains("+") Or Input.Contains("%")) And Not Input.Contains(HoldChar) Then
      Return Input.Replace("(", HoldChar & "(")
    ElseIf Input.Contains(HoldChar) Then
      Return Input
    Else
      Return HoldChar & "(" & Input & ")"
    End If
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

  Private Sub UpdateHotkeys()
    Dim arr As String()

    If IsNothing(My.Settings.F9Keys) Then My.Settings.F9Keys = New Specialized.StringCollection
    ReDim arr(lstF9.Items.Count)
    lstF9.Items.CopyTo(arr, 0)
    My.Settings.F9Keys.Clear()
    My.Settings.F9Keys.AddRange(arr)

    If IsNothing(My.Settings.F10Keys) Then My.Settings.F10Keys = New Specialized.StringCollection
    ReDim arr(lstF10.Items.Count)
    lstF10.Items.CopyTo(arr, 0)
    My.Settings.F10Keys.Clear()
    My.Settings.F10Keys.AddRange(arr)

    If IsNothing(My.Settings.F11Keys) Then My.Settings.F11Keys = New Specialized.StringCollection
    ReDim arr(lstF11.Items.Count)
    lstF11.Items.CopyTo(arr, 0)
    My.Settings.F11Keys.Clear()
    My.Settings.F11Keys.AddRange(arr)

    If IsNothing(My.Settings.F12Keys) Then My.Settings.F12Keys = New Specialized.StringCollection
    ReDim arr(lstF12.Items.Count)
    lstF12.Items.CopyTo(arr, 0)
    My.Settings.F12Keys.Clear()
    My.Settings.F12Keys.AddRange(arr)

    My.Settings.Save()
  End Sub

End Class
