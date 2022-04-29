Public Class frmScores
    ''' <summary>
    ''' Executes upon the form being opened for the first time, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub frmScores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' clears the list box
        lstScores.Items.Clear()
        ' gets the scores
        getScores()
    End Sub
    ''' <summary>
    ''' handles retrieving, sorting, and printing the scores, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub getScores()
        ' declares the highscores array
        Dim arrHighScores(highScoreLength) As recHighScore
        ' opens the scores.txt file and populates the array
        readFile(arrHighScores)
        ' sorts the array
        BubbleSort(arrHighScores)
        ' prints the sorted array
        printArr(arrHighScores)
    End Sub
    ''' <summary>
    ''' prints the highscores array into the scores list box, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub printArr(ByVal arrHighScores() As recHighScore)
        ' loops through the first 10 elements of the array
        For i = 1 To highScoreLength - 2
            ' prints the name of the recorded player and their score
            lstScores.Items.Add(i & " - " & arrHighScores(i).name)
            lstScores.Items.Add("   Fastest Win: " & arrHighScores(i).score)
            ' spaces out the scores
            lstScores.Items.Add("")
        Next i
    End Sub
    ''' <summary>
    ''' On button press takes the user back to the previous form, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' checks what form the user was previously on (1 for game screen, 2 for home screen)
        Select Case Previousfrm
            ' takes the user to the previous form
            Case 1 : frmGame.Show()
                frmGame.Location = Me.Location
            Case 2 : frmHome.Show()
                frmHome.Location = Me.Location
        End Select
        Me.Close()
    End Sub
    ''' <summary>
    ''' on button press refreshes the scores list box, used for debugging, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ' clears the listbox
        lstScores.Items.Clear()
        ' updates the listbox
        getScores()
    End Sub
End Class