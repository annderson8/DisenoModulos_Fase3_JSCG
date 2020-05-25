Public Class Questions
    Inherits System.Web.UI.Page

    Private ReadOnly Answers = New String() {"D", "A", "C", "B", "D", "B", "C", "A", "D", "C"}
    Private Const LessAView As Integer = 1
    Private Property SelectedAnswers As String()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RestartExam()
            SetVisibilityButtons(True)
        End If
    End Sub

    Private Sub SetVisibilityButtons(Visibility As Boolean)
        ButtonPreviousQuestion.Visible = Visibility
        ButtonNextQuestion.Visible = Visibility
        ButtonNextEndExam.Visible = Not Visibility
    End Sub

    Private Sub RestartExam()
        MultiViewPrincipal.SetActiveView(ViewQuestionOne)
        ClearSelectedAnswer(RadioButtonListQuestionOne)
        ClearSelectedAnswer(RadioButtonListQuestionTwo)
        ClearSelectedAnswer(RadioButtonListQuestionThree)
        ClearSelectedAnswer(RadioButtonListQuestionFour)
        ClearSelectedAnswer(RadioButtonListQuestionFive)
        ClearSelectedAnswer(RadioButtonListQuestionSix)
        ClearSelectedAnswer(RadioButtonListQuestionSeven)
        ClearSelectedAnswer(RadioButtonListQuestionEight)
        ClearSelectedAnswer(RadioButtonListQuestionNine)
        ClearSelectedAnswer(RadioButtonListQuestionTen)
        Session("Answers") = Nothing
        Session("SelectedAnswers") = Nothing
    End Sub

    Private Sub ClearSelectedAnswer(RadioButtonList As RadioButtonList)
        Const NoResponseSelection As Integer = -1
        RadioButtonList.SelectedIndex = NoResponseSelection
    End Sub

    Protected Sub ButtonNextQuestion_Click(sender As Object, e As EventArgs) Handles ButtonNextQuestion.Click
        Const NextView As Integer = 1
        Dim MaxViews = MultiViewPrincipal.Views.Count - LessAView
        If SelectedAnswer() Then
            If MultiViewPrincipal.ActiveViewIndex < MaxViews Then
                MultiViewPrincipal.ActiveViewIndex = MultiViewPrincipal.ActiveViewIndex + NextView
            Else
                SetVisibilityButtons(False)
            End If
        End If
    End Sub

    Private Function SelectedAnswer() As Boolean
        Const MoreAView = 1
        Dim ActualView As Integer
        ActualView = MultiViewPrincipal.ActiveViewIndex + MoreAView
        Dim MessageValidation As String
        MessageValidation = "In question: " & ActualView & " need to select an answer; cannot continue"
        Select Case ActualView
            Case 1
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionOne, MessageValidation)
            Case 2
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionTwo, MessageValidation)
            Case 3
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionThree, MessageValidation)
            Case 4
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionFour, MessageValidation)
            Case 5
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionFive, MessageValidation)
            Case 6
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionSix, MessageValidation)
            Case 7
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionSeven, MessageValidation)
            Case 8
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionEight, MessageValidation)
            Case 9
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionNine, MessageValidation)
            Case 10
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionTen, MessageValidation)
            Case Else
                SelectedAnswer = False
        End Select
    End Function

    Private Function ValidateSelectedAnswer(RadioButtonList As RadioButtonList, MessageValidation As String)
        Const NoSelectedResponse = 0
        If RadioButtonList.SelectedIndex < NoSelectedResponse Then
            SendMessage(MessageValidation)
            ValidateSelectedAnswer = False
        Else
            ValidateSelectedAnswer = True
        End If
    End Function

    Private Function GetAnswer(ActualView As Integer) As String
        Dim ActualAnswersPosition As Integer
        ActualAnswersPosition = ActualView - LessAView
        Select Case ActualView
            Case 1
                GetAnswer = RadioButtonListQuestionOne.SelectedValue
            Case 2
                GetAnswer = RadioButtonListQuestionTwo.SelectedValue
            Case 3
                GetAnswer = RadioButtonListQuestionThree.SelectedValue
            Case 4
                GetAnswer = RadioButtonListQuestionFour.SelectedValue
            Case 5
                GetAnswer = RadioButtonListQuestionFive.SelectedValue
            Case 6
                GetAnswer = RadioButtonListQuestionSix.SelectedValue
            Case 7
                GetAnswer = RadioButtonListQuestionSeven.SelectedValue
            Case 8
                GetAnswer = RadioButtonListQuestionEight.SelectedValue
            Case 9
                GetAnswer = RadioButtonListQuestionNine.SelectedValue
            Case 10
                GetAnswer = RadioButtonListQuestionTen.SelectedValue
            Case Else
                GetAnswer = "N/A"
        End Select
    End Function

    Private Sub SendMessage(Message As String)
        Dim sb As New StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(Message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Protected Sub ButtonPreviousQuestion_Click(sender As Object, e As EventArgs) Handles ButtonPreviousQuestion.Click
        Const MinimumNumberOfViews As Integer = 0
        If MultiViewPrincipal.ActiveViewIndex > MinimumNumberOfViews Then
            MultiViewPrincipal.ActiveViewIndex = MultiViewPrincipal.ActiveViewIndex - LessAView
        Else
            SendMessage("You can not back is on the first question")
        End If
    End Sub

    Protected Sub ButtonNextEndExam_Click(sender As Object, e As EventArgs) Handles ButtonNextEndExam.Click
        Session("Answers") = Answers
        Const StepCount As Integer = 1
        Const AnswerForValue As Integer = 0
        Dim Answer As Integer
        ReDim SelectedAnswers(Answers.Length - 1)
        For Answer = AnswerForValue To Answers.Length - 1 Step StepCount
            SelectedAnswers(Answer) = GetAnswer(Answer + StepCount)
        Next Answer
        Session("SelectedAnswers") = SelectedAnswers
        Response.Redirect("SeeAnswers.aspx")
    End Sub
End Class