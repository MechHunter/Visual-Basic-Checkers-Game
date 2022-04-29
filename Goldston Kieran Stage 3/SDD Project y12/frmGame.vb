Public Class frmGame
    ' the object structure for each checkers piece
    Public Structure RecPiece
        ' which player is in the square (0 for noone, 1 for plauer 1, 2 for player 2)
        Public Player As Integer
        ' Whether the piece is a king piece, boolean value, false by default
        Public King As Boolean
    End Structure

    ' a 2d array holding the values of each gridsquare
    Dim gameArr(8, 8) As RecPiece
    ' a 2d array of pictureboxes, each corresponding to a position in gameArr
    Dim picArr(8, 8) As PictureBox
    ' stores whether it is the first of second time a player has clicked on any of the picture boxes (resets on 2)
    Dim clicks As Integer = 0
    ' tempXstart stores the x coordinate of the picturebox clicked on while tempYstart stores the y coordinate
    Dim tempXstart, tempYstart As Integer
    ' Ulternates between 1 and 2, this governs who's turn it currently is
    Dim currentPlayer As Integer = 1
    ' counts how many moves each player has made during the match
    Dim P1MovesNum, P2MovesNum As Integer
    ' counts how many wins each player has achived in the current session
    Dim P1Wins, P2Wins As Integer
    ' stores whether a second jump must be made
    Dim secondJump As Boolean = False
    ' stores whether a piece has been taken
    Dim tookPiece As Boolean = False
    ' stores if a win has been achieved
    Dim win As Boolean = False
    ' stores the total number of matches played during the current session
    Dim totalMatches As Integer
    ''' <summary>
    ''' Executes upon the form being opened for the first time, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        P1Wins = 0
        P2Wins = 0
        totalMatches = 0
        setGame()
    End Sub
    ''' <summary>
    ''' resets all aspects of the game (excluding scores), written by Kieran Goldston 2021
    ''' </summary>
    Private Sub setGame()
        ' set up the game array
        arrSetup(gameArr)
        ' assigns picture boxes to buttons
        initialisePicArr(picArr)
        ' places images on grid
        SetGameBoard(picArr, gameArr)
        ' puts things in 'game statistics' list box
        updatelstBox()
        ' resets the number of moves the players have made
        P1MovesNum = 0
        P2MovesNum = 0
        ' notifies the user[s] of which player is starting
        playerStarts()
    End Sub
    ''' <summary>
    ''' notifies user[s] which player is starting, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub playerStarts()
        ' checks which player's turn it is
        Select Case currentPlayer
            ' notifies user[s] which player is starting
            Case 1 : MsgBox("White Starts! (" & P1Name & ")")
            Case 2 : MsgBox("Black Starts! (" & P2Name & ")")
        End Select
    End Sub
    ''' <summary>
    ''' sets up gamearr, adding player 1 and 2's pieces and empty spaces, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="gameArr"></param>
    Private Sub arrSetup(ByVal gameArr(,) As RecPiece)
        ' loop through each x position of the array
        For x = 1 To 8
            ' loop through each y position of the array
            For y = 1 To 8
                ' if the y is a multiple of 2 and the x is less than 4 but does not equal 2 or y is not divisable by two but x is equal to 2
                If (y Mod 2 = 0 And x < 4 And Not x = 2) Or (y Mod 2 <> 0 And x = 2) Then
                    gameArr(x, y).Player = 1
                ElseIf (y Mod 2 <> 0 And x > 5 And Not x = 7) Or (y Mod 2 = 0 And x = 7) Then ' if the y is not a multiple of 2 and the x is greater than 5 but does not equal 7 or y is divisable by two and x is equal to 7
                    gameArr(x, y).Player = 2
                Else ' if none of the above statements apply than there is no piece in the square
                    gameArr(x, y).Player = 0
                End If
                ' resets the king value of each piece to false
                gameArr(x, y).King = False
            Next y
        Next x
    End Sub
    ''' <summary>
    ''' Sets up the game board (what the user actually sees) with the information provided by the btnarr, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="picArr">2d array of buttons, correlating to each gamearr index</param>
    ''' <param name="gameArr">2d array containing the information of each grid space on the board</param>
    Private Sub SetGameBoard(ByRef picArr(,) As PictureBox, ByRef gameArr(,) As RecPiece)
        ' increment the x element in the array, loop through each x element
        For x = 1 To 8
            ' increment the y element in the array, loop through each y element
            For y = 1 To 8
                If (y Mod 2 = 0 And x Mod 2 <> 0) Or (y Mod 2 <> 0 And x Mod 2 = 0) Then
                    ' checks if a piece is a king piece, if it is than it gets a little crown
                    If gameArr(x, y).King = True Then
                        placePieceKing(x, y)
                    Else
                        placePiece(x, y)
                    End If
                Else
                    ' if the picture box is not one of the 'ever second square is a black square' it is assigned to be white and empty
                    picArr(x, y).Image = Image.FromFile("whiteEmpty.png")
                End If
            Next y
        Next x
    End Sub
    ''' <summary>
    ''' prints the game array into the listbox, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="gameArr">2d array containing the information of each grid space on the board</param>
    Private Sub printArr(ByRef gameArr(,) As RecPiece)
        ' as the name suggests, a temporary string
        Dim tempString As String

        ' loop through the x elements of the game array
        For x = 1 To 8
            ' resets tempstring for each new column
            tempString = ""
            ' loop through the y elements of the game array
            For y = 1 To 8
                ' adds each element on the y axis of the gamearray to the string
                tempString = tempString & gameArr(x, y).Player
            Next y
            'prints the array
            lstGameStats.Items.Add(tempString)
        Next x
    End Sub
    ''' <summary>
    ''' executes when any of the game's grid buttons are clicked, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub picBox_Click(sender As Object, e As EventArgs) Handles picBox21.Click, picBox41.Click, picBox61.Click, picBox81.Click, picBox12.Click, picBox32.Click, picBox52.Click, picBox72.Click, picBox23.Click, picBox43.Click, picBox63.Click, picBox83.Click, picBox14.Click, picBox34.Click, picBox54.Click, picBox74.Click, picBox25.Click, picBox45.Click, picBox65.Click, picBox85.Click, picBox16.Click, picBox36.Click, picBox56.Click, picBox76.Click, picBox27.Click, picBox47.Click, picBox67.Click, picBox87.Click, picBox18.Click, picBox38.Click, picBox58.Click, picBox78.Click
        ' gets the name of the picture box that was clicked on
        Dim cname As String = sender.name
        ' gets the 2 rightmost characters in the name of the button that was clicked on
        Dim clickedButton As String = Strings.Right(cname, 2)
        ' splits clickedButton into 2 seperate variables, corrisponding to the picture box's x and y
        Dim clickedBtnX As Integer = Int(Strings.Left(clickedButton, 1))
        Dim clickedBtnY As Integer = Int(Strings.Right(clickedButton, 1))

        ' processes the button click
        handleBtnClicks(clickedBtnX, clickedBtnY)
    End Sub
    ''' <summary>
    ''' handles every aspect of the gameplay. Mainly it gets the first and second button positions and checks whether a win has been achieved, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picture box the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picture box the player has clicked on</param>
    Private Sub handleBtnClicks(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer)
        ' increments the number of clicks
        clicks = clicks + 1

        ' if is the first box the player has clicked on
        If clicks = 1 And secondJump = False Then
            ' sets the first buttons that the player has clicked on, and stores this
            tempXstart = clickedBtnX
            tempYstart = clickedBtnY

            ' highlights the space the player has clicked on
            highlightSpace(2, clickedBtnX, clickedBtnY, tempXstart, tempYstart)

            ' if it is the second box the player has clicked on
        ElseIf clicks = 2 Then
            ' resets clicks
            clicks = 0
            ' checks if the move is valid and moves the piece
            checkPieceMove(clickedBtnX, clickedBtnY, tempXstart, tempYstart)

            ' checks if a win has been achieved
            If checkWin() = True Or win = True Then
                processWin()
            End If

            ' updates the list box
            updatelstBox()
            ' unhighlights the space
            highlightSpace(1, clickedBtnX, clickedBtnY, tempXstart, tempYstart)
        End If
    End Sub
    ''' <summary>
    ''' handles a win scenario, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub processWin()
        ' checks who has won and notifes the user[s]
        Select Case currentPlayer
            Case 2 : P1Wins = P1Wins + 1
                MsgBox(P1Name & " Wins!")
            Case 1 : P2Wins = P2Wins + 1
                MsgBox(P2Name & " Wins!")
        End Select

        ' increments the total matches played
        totalMatches = totalMatches + 1
        'updates the scores
        updateScores()
        'resets the game board
        setGame()
    End Sub
    ''' <summary>
    ''' refreshes the game statistics listbox with new infomation, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub updatelstBox()
        ' tracks the total number of moves made during the current match
        Dim totalMoves As Integer = P1MovesNum + P2MovesNum
        ' clears the listbox
        lstGameStats.Items.Clear()

        ' prints the contents of the array, used for debugging
        'printArr(gameArr)

        ' displays which player's turn it is
        Select Case currentPlayer
            Case 1 : lstGameStats.Items.Add(P1Name & "'s turn")
            Case 2 : lstGameStats.Items.Add(P2Name & "'s turn")
        End Select

        ' updates match information in the list box
        lstGameStats.Items.Add(P1Name & ", Wins: " & P1Wins)
        lstGameStats.Items.Add("    " & " Moves: " & P1MovesNum)
        lstGameStats.Items.Add(P2Name & ", Wins: " & P2Wins)
        lstGameStats.Items.Add("    " & " Moves: " & P2MovesNum)
        lstGameStats.Items.Add("Total number of matches: " & totalMatches)
        lstGameStats.Items.Add("Total moves this match: " & totalMoves)
    End Sub
    ''' <summary>
    ''' Handles the logic behind moving pieces. Passes the first and second button positions to each validate and check function. Also handles if a player must take a piece, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picture box the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picture box the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picture box the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picture box the player has clicked on</param>
    Private Sub checkPieceMove(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer)
        ' checks if the move is valid
        If validateMove(clickedBtnX, clickedBtnY, Xstart, Ystart) = True Then
            ' checks the player has taken a piece they must take or has made a valid move without having to take a piece
            If mustJump() = True And validPieceTake(clickedBtnX, clickedBtnY, Xstart, Ystart) = True Or mustJump() = False Then
                ' checks if the piece has reached the end of the board
                checkKing(clickedBtnX, clickedBtnY, Xstart, Ystart)
                ' moves the piece to its new position
                movePiece(clickedBtnX, clickedBtnY, Xstart, Ystart)

                ' increments the number of moves the player that moved has made during the current match
                Select Case currentPlayer
                    Case 1 : P1MovesNum = P1MovesNum + 1
                    Case 2 : P2MovesNum = P2MovesNum + 1
                End Select

                ' checks if the piece can take another piece and has already taken a piece
                If checkValidPieceTakes(clickedBtnX, clickedBtnY) = True And tookPiece = True Then
                    ' unhighlights where the piece moved from
                    highlightSpace(1, clickedBtnX, clickedBtnY, Xstart, Ystart)
                    ' stores the fact that a second jump can be made as a boolean
                    secondJump = True
                    ' resets the clicks
                    clicks = 1

                    ' sets the 'first button clicked on' to be where the piece moved to
                    tempXstart = clickedBtnX
                    tempYstart = clickedBtnY

                    ' highlights where the piece moved to
                    highlightSpace(2, clickedBtnX, clickedBtnY, Xstart, Ystart)
                    ' notifies the player
                    MsgBox("You can make another jump!")
                Else
                    ' otherwise resets secondJump and changes turn
                    secondJump = False
                    currentPlayer = 2 / currentPlayer
                End If
            Else
                ' if a player has attempted to move but must take a piece
                ' notifies the player
                MsgBox("There is a piece you must take!")
            End If
        End If
    End Sub
    ''' <summary>
    ''' highlights (makes the square green) the picture box that has been clicked on, or unhighlights a highlighted box, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="highlight">Determines whether the piece will be highlighted or unhighlighted (1 for unhighlight, 2 for highlight)</param>
    ''' <param name="clickedBtnX">the x position of the most current picture box the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picture box the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picture box the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picture box the player has clicked on</param>
    Private Sub highlightSpace(highlight As Integer, ByVal clickedBtnX As Integer, ByVal clickedBtnY As Integer, ByVal Xstart As Integer, ByVal Ystart As Integer)
        ' whether the box should be highlighted or unhighlighted
        Select Case highlight
            ' deselect / unhighlight piece
            Case 1
                ' Checks if a piece is a king piece, if it is than it gets a little crown
                If gameArr(Xstart, Ystart).King = True Then
                    placePieceKing(Xstart, Ystart)
                Else
                    placePiece(Xstart, Ystart)
                End If
            ' select / highlight piece
            Case 2
                If gameArr(clickedBtnX, clickedBtnY).King = True Then
                    selectPieceKing(clickedBtnX, clickedBtnY)
                Else
                    selectPiece(clickedBtnX, clickedBtnY)
                End If
        End Select
    End Sub
    ''' <summary>
    ''' assigns a picture to a picture box to a corresponding grid square, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">picture box / game array x position</param>
    ''' <param name="y">picture box / game array y position</param>
    Private Sub placePiece(ByVal x As Integer, ByVal y As Integer)
        ' checks for what kind of piece is in the x,y position of the gameArray and assigns a picture to the corresponding picture box
        ' Name convention of images: tile colour, piece colour, King (nothing if not a king)
        Select Case gameArr(x, y).Player
            Case 0 : picArr(x, y).Image = Image.FromFile("blackEmpty.png")
            Case 1 : picArr(x, y).Image = Image.FromFile("blackWhite.png")
            Case 2 : picArr(x, y).Image = Image.FromFile("blackBlack.png")
        End Select
    End Sub
    ''' <summary>
    ''' assigns a picture to a picture box to a corresponding grid square, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">picture box / game array x position</param>
    ''' <param name="y">picture box / game array y position</param>
    Private Sub selectPiece(ByVal x As Integer, ByVal y As Integer)
        ' checks for what kind of piece is in the x,y position of the gameArray and assigns a picture to the corresponding picture box
        ' Name convention of images: tile colour, piece colour, King (nothing if not a king)
        Select Case gameArr(x, y).Player
            Case 0 : picArr(x, y).Image = Image.FromFile("selectEmpty.png")
            Case 1 : picArr(x, y).Image = Image.FromFile("selectWhite.png")
            Case 2 : picArr(x, y).Image = Image.FromFile("selectBlack.png")
        End Select
    End Sub
    ''' <summary>
    ''' assigns a picture to a picture box to a corresponding grid square, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">picture box / game array x position</param>
    ''' <param name="y">picture box / game array y position</param>
    Private Sub placePieceKing(ByVal x As Integer, ByVal y As Integer)
        ' checks for what kind of piece is in the x,y position of the gameArray and assigns a picture to the corresponding picture box
        ' Name convention of images: tile colour, piece colour, King (nothing if not a king)
        Select Case gameArr(x, y).Player
            Case 0 : picArr(x, y).Image = Image.FromFile("blackEmpty.png")
            Case 1 : picArr(x, y).Image = Image.FromFile("blackWhiteKing.png")
            Case 2 : picArr(x, y).Image = Image.FromFile("blackBlackKing.png")
        End Select
    End Sub
    ''' <summary>
    ''' assigns a picture to a picture box to a corresponding grid square, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">picture box / game array x position</param>
    ''' <param name="y">picture box / game array y position</param>
    Private Sub selectPieceKing(ByVal x As Integer, ByVal y As Integer)
        ' checks for what kind of piece is in the x,y position of the gameArray and assigns a picture to the corresponding picture box
        ' Name convention of images: tile colour, piece colour, King (nothing if not a king)
        Select Case gameArr(x, y).Player
            Case 0 : picArr(x, y).Image = Image.FromFile("selectEmpty.png")
            Case 1 : picArr(x, y).Image = Image.FromFile("selectWhiteKing.png")
            Case 2 : picArr(x, y).Image = Image.FromFile("selectBlackKing.png")
        End Select
    End Sub
    ''' <summary>
    ''' Handles moving pieces, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    Private Sub movePiece(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer)
        ' the x and y positions of the box directly in the centre of where the piece is jumping from and to
        Dim Xmid As Integer = (Xstart + clickedBtnX) / 2
        Dim Ymid As Integer = (Ystart + clickedBtnY) / 2

        ' checks if the move is a valid piece take
        If validPieceTake(clickedBtnX, clickedBtnY, Xstart, Ystart) = True Then
            ' if a piece has been taken, the piece is removed from the game array
            gameArr(Xmid, Ymid).Player = 0
            gameArr(Xmid, Ymid).King = False
            tookPiece = True
        Else
            ' no pieces were taken
            tookPiece = False
        End If

        ' moves the piece to the location of the second click
        gameArr(clickedBtnX, clickedBtnY).Player = gameArr(Xstart, Ystart).Player
        gameArr(clickedBtnX, clickedBtnY).King = gameArr(Xstart, Ystart).King
        gameArr(Xstart, Ystart).Player = 0
        gameArr(Xstart, Ystart).King = False

        'updates the game board
        SetGameBoard(picArr, gameArr)
    End Sub
    ''' <summary>
    ''' Checks whether the move a player is attempting to make is valid, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    ''' <returns> a boolean value</returns>
    Private Function validateMove(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer) As Boolean
        ' whether the move the player made is valid, as a boolean
        Dim validMove = False

        ' checks if the piece being moved is within the bounds of the array
        If clickedBtnX <= 8 And clickedBtnX >= 1 And clickedBtnY <= 8 And clickedBtnY >= 1 Then
            ' checks each validation function / rule
            If (validSingleJump(clickedBtnX, clickedBtnY, Xstart, Ystart) = True Or validPieceTake(clickedBtnX, clickedBtnY, Xstart, Ystart) = True) And gameArr(Xstart, Ystart).Player <> 0 And gameArr(clickedBtnX, clickedBtnY).Player = 0 And gameArr(Xstart, Ystart).Player = currentPlayer And validBackwardsMove(clickedBtnX, clickedBtnY, Xstart, Ystart) = True Then
                validMove = True
            End If
        End If

        Return validMove
    End Function
    ''' <summary>
    ''' Checks whether a backwards move is valid, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    ''' <returns> a boolean value</returns>
    Private Function validBackwardsMove(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer) As Boolean
        ' whether the move the player made is a valid backwards move, as a boolean
        Dim validMove As Boolean = False
        ' gets the direction the piece moved (negative for backwards, positive for forwards)
        Dim direction As Integer = clickedBtnX - Xstart

        ' checks what turn it is and checks the direction
        If (currentPlayer = 1 And direction > 0) Then
            validMove = True

        ElseIf (currentPlayer = 2 And direction < 0) Then
            validMove = True

            ' if the piece is a king piece it can move in any direction
        ElseIf gameArr(Xstart, Ystart).King = True Then
            validMove = True
        End If

        Return validMove
    End Function
    ''' <summary>
    ''' Checks whether a piece take is valid, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    ''' <returns> a boolean value</returns>
    Private Function validPieceTake(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer) As Boolean
        ' whether the move the player made is a valid piece take, as a boolean
        Dim validMove As Boolean = False
        ' gets the x and y values of between when the piece was moved from and to
        Dim Xmid As Integer = (Xstart + clickedBtnX) / 2
        Dim Ymid As Integer = (Ystart + clickedBtnY) / 2
        ' gets the distance that the piece had jumped
        Dim jumpLengthX As Integer = Xstart - clickedBtnX
        Dim jumpLengthY As Integer = Ystart - clickedBtnY

        ' checks whether it will be checking for a piece take within the bounds of the array
        If Xmid < 8 And Xmid > 1 And Ymid < 8 And Ymid > 1 And clickedBtnX <= 8 And clickedBtnX >= 1 And clickedBtnY <= 8 And clickedBtnY >= 1 Then
            ' checks if there is a piece between where the piece started and where it has jumped to
            If gameArr(Xmid, Ymid).Player = 2 / currentPlayer And gameArr(Xstart, Ystart).Player <> 0 And gameArr(clickedBtnX, clickedBtnY).Player = 0 And validBackwardsMove(clickedBtnX, clickedBtnY, Xstart, Ystart) = True And (jumpLengthX = 2 Or jumpLengthX = -2) And (jumpLengthY = 2 Or jumpLengthY = -2) Then
                validMove = True
            End If
        End If

        Return validMove
    End Function
    ''' <summary>
    ''' Checks a basic single square jump is valid, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    ''' <returns> a boolean value</returns>
    Private Function validSingleJump(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer) As Boolean
        ' whether the move the player made is a valid single jump, as a boolean
        Dim validMove = False
        ' gets the number of squares the piece has moved
        Dim jumpLengthX As Integer = Xstart - clickedBtnX
        Dim jumpLengthY As Integer = Ystart - clickedBtnY

        ' only allows the player to jump if they have moved by 1 square, cant be more than 1
        If (jumpLengthX = 1 Or jumpLengthX = -1) And (jumpLengthY = 1 Or jumpLengthY = -1) Then
            validMove = True
        End If

        Return validMove
    End Function
    ''' <summary>
    ''' Checks if a player must take a piece, written by Kieran Goldston 2021
    ''' </summary>
    ''' <returns> a boolean value</returns>
    Private Function mustJump() As Boolean
        ' false if there are no available piece takes
        Dim availableMoves As Boolean = False

        ' loops through every grid square
        For x = 1 To 8
            For y = 1 To 8
                ' checks whether there is a piece in the square, if so then executes
                If (y Mod 2 = 0 And x Mod 2 <> 0) Or (y Mod 2 <> 0 And x Mod 2 = 0) Then
                    ' checks if the piece in the square is a piece of the player who's turn it currently is
                    ' and checks if there are any valid piece takes for that piece, if so available moves is set to true
                    If gameArr(x, y).Player = currentPlayer And checkValidPieceTakes(x, y) = True Then
                        availableMoves = True
                    End If
                End If
            Next y
        Next x

        Return availableMoves
    End Function
    ''' <summary>
    ''' Checks if a piece has reached the edge of the board and is now kinged, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="clickedBtnX">the x position of the most current picturebox the player has clicked on</param>
    ''' <param name="clickedBtnY">the y position of the most current picturebox the player has clicked on</param>
    ''' <param name="Xstart">the x position of the first picturebox the player has clicked on</param>
    ''' <param name="Ystart">the y position of the first picturebox the player has clicked on</param>
    Private Sub checkKing(ByRef clickedBtnX As Integer, ByRef clickedBtnY As Integer, ByRef Xstart As Integer, ByRef Ystart As Integer)
        ' checks if the piece the player has clicked on has reached the other side of the board
        ' checks if player 1's piece
        If gameArr(Xstart, Ystart).Player = 1 And clickedBtnX = 8 Then
            ' sets piece.king to true
            gameArr(Xstart, Ystart).King = True

            ' checks if player 2's piece
        ElseIf gameArr(Xstart, Ystart).Player = 2 And clickedBtnX = 1 Then
            gameArr(Xstart, Ystart).King = True
        End If
    End Sub
    ''' <summary>
    ''' Handles checking whether a win has been achieved, written by Kieran Goldston 2021
    ''' </summary>
    ''' <returns> a boolean value</returns>
    Private Function checkWin() As Boolean
        ' boolean that keeps track of if a win has been achieved, by default false
        Dim win As Boolean = False

        ' checks if either of the win conditions have been achieved, if so win is set to true
        If checkPieces(gameArr) = True Or checkAvailableMoves(gameArr) = False Then
            win = True
        End If

        Return win
    End Function
    ''' <summary>
    ''' Checks grid square for a player's pieces, if they dont have any pieces than it returns true, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="gameArr">2d array containing the information of each grid space on the board</param>
    ''' <returns> a boolean value</returns>
    Private Function checkPieces(ByRef gameArr(,) As RecPiece) As Boolean
        ' false if a win has not been achieved
        Dim win As Boolean = False
        ' keeps track of how many pieces each player has
        ' it can be any number however if it is over 1, the function will return true
        Dim numP1Pieces As Integer = 0
        Dim numP2Pieces As Integer = 0

        ' loops through every grid square
        For x = 1 To 8
            For y = 1 To 8
                ' checks in there is a piece in the square
                If (y Mod 2 = 0 And x Mod 2 <> 0) Or (y Mod 2 <> 0 And x Mod 2 = 0) Then
                    ' if the piece is a player1's piece it increments the counted number of player1 pieces
                    ' otherwise if it is a player2's piece it increments the counted number of player2 pieces
                    Select Case gameArr(x, y).Player
                        Case 1 : numP1Pieces = numP1Pieces + 1
                        Case 2 : numP2Pieces = numP2Pieces + 1
                    End Select
                End If
            Next y
        Next x

        ' if there are no pieces then a win has been achieved and sets win to true
        If numP1Pieces = 0 Or numP2Pieces = 0 Then
            win = True
        End If

        Return win
    End Function
    ''' <summary>
    ''' Checks whether a player has any available moves, if not returns false, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="gameArr">2d array containing the information of each grid space on the board</param>
    ''' <returns> a boolean value</returns>
    Private Function checkAvailableMoves(ByRef gameArr(,) As RecPiece) As Boolean
        ' false if there are no available moves
        Dim availableMoves As Boolean = False

        ' loops through every grid square
        For x = 1 To 8
            For y = 1 To 8
                ' checks whether there is a piece in the square, if so then executes
                If (y Mod 2 = 0 And x Mod 2 <> 0) Or (y Mod 2 <> 0 And x Mod 2 = 0) Then
                    ' checks if the piece in the square is a piece of the player who's turn it currently is
                    ' and checks if there are any valid moves for that piece, if so available moves is set to true
                    If gameArr(x, y).Player = currentPlayer And checkValidMoves(x, y) = True Then
                        availableMoves = True
                    End If
                End If
            Next y
        Next x

        Return availableMoves
    End Function
    ''' <summary>
    ''' checks each piece a player has and if it can make a valid piece take, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">test x position</param>
    ''' <param name="y">test y position</param>
    ''' <returns> a boolean value</returns>
    Private Function checkValidPieceTakes(ByRef x As Integer, ByRef y As Integer) As Boolean
        ' false if there are no available moves
        Dim availableMoves As Boolean = False

        ' checks whether the piece at (x,y) can make any valid piece takes, if so then sets available moves to true
        If validPieceTake(x + 2, y + 2, x, y) = True Or validPieceTake(x + 2, y - 2, x, y) = True Or validPieceTake(x - 2, y + 2, x, y) = True Or validPieceTake(x - 2, y - 2, x, y) = True Then
            availableMoves = True
        End If

        Return availableMoves
    End Function
    ''' <summary>
    ''' Checks each piece a player has and if it can make any valid move, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="x">test x position</param>
    ''' <param name="y">test y position</param>
    ''' <returns> a boolean value</returns>
    Private Function checkValidMoves(ByRef x As Integer, ByRef y As Integer) As Boolean
        ' false if there are no available moves
        Dim availableMoves As Boolean = False

        ' checks whether the piece at (x,y) can make any moves in any direction, if so then sets available moves to true
        If validateMove(x + 1, y + 1, x, y) = True Or validateMove(x + 1, y - 1, x, y) = True Or validateMove(x - 1, y + 1, x, y) = True Or validateMove(x - 1, y - 1, x, y) = True Or checkValidPieceTakes(x, y) = True Then
            availableMoves = True
        End If

        Return availableMoves
    End Function
    ''' <summary>
    ''' Sets up the button array, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="picArr">2d array of picture boxes, correlating to each gamearr index</param>
    Private Sub initialisePicArr(picArr(,) As PictureBox)
        ' each line assigns a different picture box on the grid with a index in pixArr
        ' they grouped by column number
        picArr(1, 1) = picBox11
        picArr(2, 1) = picBox21
        picArr(3, 1) = picBox31
        picArr(4, 1) = picBox41
        picArr(5, 1) = picBox51
        picArr(6, 1) = picBox61
        picArr(7, 1) = picBox71
        picArr(8, 1) = picBox81

        picArr(1, 2) = picBox12
        picArr(2, 2) = picBox22
        picArr(3, 2) = picBox32
        picArr(4, 2) = picBox42
        picArr(5, 2) = picBox52
        picArr(6, 2) = picBox62
        picArr(7, 2) = picBox72
        picArr(8, 2) = picBox82

        picArr(1, 3) = picBox13
        picArr(2, 3) = picBox23
        picArr(3, 3) = picBox33
        picArr(4, 3) = picBox43
        picArr(5, 3) = picBox53
        picArr(6, 3) = picBox63
        picArr(7, 3) = picBox73
        picArr(8, 3) = picBox83

        picArr(1, 4) = picBox14
        picArr(2, 4) = picBox24
        picArr(3, 4) = picBox34
        picArr(4, 4) = picBox44
        picArr(5, 4) = picBox54
        picArr(6, 4) = picBox64
        picArr(7, 4) = picBox74
        picArr(8, 4) = picBox84

        picArr(1, 5) = picBox15
        picArr(2, 5) = picBox25
        picArr(3, 5) = picBox35
        picArr(4, 5) = picBox45
        picArr(5, 5) = picBox55
        picArr(6, 5) = picBox65
        picArr(7, 5) = picBox75
        picArr(8, 5) = picBox85

        picArr(1, 6) = picBox16
        picArr(2, 6) = picBox26
        picArr(3, 6) = picBox36
        picArr(4, 6) = picBox46
        picArr(5, 6) = picBox56
        picArr(6, 6) = picBox66
        picArr(7, 6) = picBox76
        picArr(8, 6) = picBox86

        picArr(1, 7) = picBox17
        picArr(2, 7) = picBox27
        picArr(3, 7) = picBox37
        picArr(4, 7) = picBox47
        picArr(5, 7) = picBox57
        picArr(6, 7) = picBox67
        picArr(7, 7) = picBox77
        picArr(8, 7) = picBox87

        picArr(1, 8) = picBox18
        picArr(2, 8) = picBox28
        picArr(3, 8) = picBox38
        picArr(4, 8) = picBox48
        picArr(5, 8) = picBox58
        picArr(6, 8) = picBox68
        picArr(7, 8) = picBox78
        picArr(8, 8) = picBox88
    End Sub
    ''' <summary>
    ''' will take the user to the High Scores screen on button press, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub BtnHighScores_Click(sender As Object, e As EventArgs) Handles BtnHighScores.Click
        ' sets the previous form to be that of the game form
        Previousfrm = 1
        frmScores.Show()
        frmScores.Location = Me.Location
        Me.Hide()
    End Sub
    ''' <summary>
    ''' will take the user to the help screen on button press, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">>Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.Show()
        frmHelp.Location = Me.Location
    End Sub

    ''' <summary>
    ''' Will take the user to the Home screen on button press, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ' changes the previous form to be that of the game form
        Previousfrm = 1
        frmHome.Show()
        frmHome.Location = Me.Location
        Me.Close()
    End Sub
    ''' <summary>
    ''' Gets both player 1 and 2's scores and updates them based on who has won or if their names already exist in the scores file, written by Kieran Goldston 2021
    ''' </summary>
    Private Sub updateScores()
        ' high scores array
        Dim arrHighScores(highScoreLength) As recHighScore
        ' if the value is false than the user doesn't already exist in the file
        Dim oldUser As Boolean = False

        ' reads from file
        readFile(arrHighScores)

        ' loops through the highScore array, and checks if either player 1 or 2 already exists
        For i = 1 To highScoreLength
            ' checks if the current player's name already exists in the file
            Select Case arrHighScores(i).name
                Case P1Name
                    ' checks if they were the player that won the match
                    If currentPlayer = 2 Then
                        ' checks if the achieved number of moves for a win is less than that which has been previously recorded, if it is than a new score is set
                        If arrHighScores(i).score > P1MovesNum Then
                            arrHighScores(i).score = P1MovesNum
                        End If
                        oldUser = True
                    End If
                Case P2Name
                    If currentPlayer = 1 Then
                        If arrHighScores(i).score > P2MovesNum Then
                            arrHighScores(i).score = P2MovesNum
                        End If
                        oldUser = True
                    End If
            End Select
        Next i

        ' if the user doesn't exist in the file the two player's scores are put in the last two elements of the array
        If oldUser = False Then
            arrHighScores(highScoreLength - 2).name = P1Name
            arrHighScores(highScoreLength - 2).score = P1MovesNum
            arrHighScores(highScoreLength - 1).name = P2Name
            arrHighScores(highScoreLength - 1).score = P2MovesNum
        End If

        ' scores are sorted
        BubbleSort(arrHighScores)
        ' scores are updated in the file
        writeFile(arrHighScores)
    End Sub
    ''' <summary>
    ''' a button for testing wins and scoring by instantly winning the game, written by Kieran Goldston 2021
    ''' </summary>
    ''' <param name="sender">Reference to the control which called the subroutine</param>
    ''' <param name="e">>Provides more information about the event that caused this subroutine to be called</param>
    Private Sub btnWin_Click(sender As Object, e As EventArgs) Handles btnWin.Click
        ' sets a boolean variable that bypasses the win conditions to true
        win = True
    End Sub
End Class
