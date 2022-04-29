Module Module1
    ' the object structure for each player and their highscore
    Public Structure recHighScore
        ' player's name
        Public name As String
        ' player's score
        Public score As Integer
    End Structure

    ' a constant defining how long the highscores array should be
    Public Const highScoreLength As Integer = 12
    ' the pevious form that the player was on
    Public Previousfrm As Integer
    ' player 1 and 2's names
    Public P1Name As String
    Public P2Name As String
    ''' <summary>
    ''' reads the items in the file 'scores.txt' and inputs them into the array of records arrHighScores, written by Kieran Goldston 2021
    ''' </summary>
    Public Sub readFile(ByRef arrHighScores() As recHighScore)
        ' opens scores.txt file
        FileSystem.FileOpen(1, "scores.txt", OpenMode.Input)

        'populates the array with the contents of the file
        For i = 1 To highScoreLength
            FileSystem.Input(1, arrHighScores(i).name)
            FileSystem.Input(1, arrHighScores(i).score)
        Next i

        ' closes the file
        FileSystem.FileClose()
    End Sub
    ''' <summary>
    ''' sorts the items in arrHighScores, written by Kieran Goldston 2021
    ''' </summary>
    Public Sub BubbleSort(ByRef arrHighScores() As recHighScore)
        ' last index of the unsorted array
        Dim last As Integer = highScoreLength
        ' stores if two elements have been swapped
        Dim swapped As Boolean = True

        ' while there are elements that are unsorted (The algorithm has had to swap two elements) the array is looped through and sorted
        While swapped = True
            ' if swapped is not set to be true again (no elements were swapped) the loop will exit
            swapped = False
            ' position in the array
            Dim i As Integer = 1

            ' while i is less than the last index of the unsorted section of the array
            While i < last
                ' if an element is greater than the next, they are swapped so that the array is sorted in acending order
                ' (element at index 1 will be the smallest while the last element will be the largest)
                If arrHighScores(i).score > arrHighScores(i + 1).score Then
                    ' swaps element in the array with the next
                    swap(arrHighScores(i), arrHighScores(i + 1))
                    ' swapped is set back to true
                    swapped = True
                End If
                ' increment i
                i = i + 1
            End While

            ' decrement the last index of the unsorted array
            last = last - 1
        End While
    End Sub
    ''' <summary>
    ''' swaps the position of two input variables, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="A">the first variable</param>
    ''' <param name="B">the second variable</param>
    Public Sub swap(ByRef A As recHighScore, ByRef B As recHighScore)
        ' swaps A with B, temp temporarily stores A so that A is not overwritten
        Dim temp As recHighScore = A
        A = B
        B = temp
    End Sub
    ''' <summary>
    ''' writes the array of records arrHighScores into the file 'scores.txt', written by Kieran Goldston 2021
    ''' </summary>
    Public Sub writeFile(ByRef arrHighScores() As recHighScore)
        ' opens the scores.txt file
        FileSystem.FileOpen(1, "scores.txt", OpenMode.Output)

        ' writes the contents of the array into the file
        For i = 1 To highScoreLength
            FileSystem.WriteLine(1, arrHighScores(i).name)
            FileSystem.WriteLine(1, arrHighScores(i).score)
        Next i

        ' closes the file
        FileSystem.FileClose()
    End Sub
End Module
