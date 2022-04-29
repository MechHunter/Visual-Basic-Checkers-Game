Public Class frmHome
    ''' <summary>
    ''' checks whether the two names the players have entered are valid, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="player1Name">stores player 1's name</param>
    ''' <param name="player2Name">stores player 2's name</param>
    ''' <returns> a boolean value</returns>
    Private Function validatePlayerName(player1Name As String, player2Name As String) As Boolean
        ' constants defining the minimum and maximum length of the player names
        Const min As Integer = 3
        Const max As Integer = 10
        ' stores whether the name is valid, as a boolean
        Dim valid As Boolean = False

        ' checks if the player name is valid
        If player1Name.Length <= max And player2Name.Length <= max And player1Name.Length >= min And player2Name.Length >= min Then
            valid = True
        End If

        ' returns if the player name is valid
        Return valid
    End Function
    ''' <summary>
    ''' will take the user to the game screen on button press, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        ' calls the player name validation function
        If validatePlayerName(txtPlayer1.Text, txtPlayer2.Text) = True Then
            ' sets the previous form to be that of the home screen
            Previousfrm = 2
            ' sets the players' names to be what is written in the text boxes
            P1Name = txtPlayer1.Text
            P2Name = txtPlayer2.Text
            ' opens the game form
            frmGame.Show()
            frmGame.Location = Me.Location
            Me.Close()
        Else
            ' notifies the user[s] is one of the names is invalid (does not say which one)
            MsgBox("Player 1 or 2's names are not valid")
        End If
    End Sub
    ''' <summary>
    ''' will take the user to the High Scores screen on button press, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnHighScores_Click(sender As Object, e As EventArgs) Handles btnHighScores.Click
        ' sets the previous form to be that of the home screen
        Previousfrm = 2
        ' opens the highscores form
        frmScores.Show()
        frmScores.Location = Me.Location
        Me.Close()
    End Sub
    ''' <summary>
    ''' will open the help window for the user, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        ' opens the help form
        frmHelp.Show()
        frmHelp.Location = Me.Location
    End Sub
End Class