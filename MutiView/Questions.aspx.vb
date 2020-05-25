Public Class Questions
    Inherits System.Web.UI.Page

    Private ReadOnly Answers = New String() {"D", "A", "C", "B", "D", "B", "C", "A", "D", "C"}
    Private Property AnswersCounter As Integer
    Private Const LessAView As Integer = 1

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
        ButtonRestartExam.Visible = Not Visibility
    End Sub

    Private Sub RestartExam()
        Const NoAnswers As Integer = 0
        MultiViewPrincipal.SetActiveView(ViewQuestionOne)
        AnswersCounter = NoAnswers
        Session.Add("AnswersCounter", AnswersCounter)
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

    Private Sub AddAnswer(ActualView As Integer)
        Dim ActualAnswersPosition As Integer
        ActualAnswersPosition = ActualView - LessAView
        Select Case ActualView
            Case 1
                ValidationAnswer(RadioButtonListQuestionOne, ActualAnswersPosition)
            Case 2
                ValidationAnswer(RadioButtonListQuestionTwo, ActualAnswersPosition)
            Case 3
                ValidationAnswer(RadioButtonListQuestionThree, ActualAnswersPosition)
            Case 4
                ValidationAnswer(RadioButtonListQuestionFour, ActualAnswersPosition)
            Case 5
                ValidationAnswer(RadioButtonListQuestionFive, ActualAnswersPosition)
            Case 6
                ValidationAnswer(RadioButtonListQuestionSix, ActualAnswersPosition)
            Case 7
                ValidationAnswer(RadioButtonListQuestionSeven, ActualAnswersPosition)
            Case 8
                ValidationAnswer(RadioButtonListQuestionEight, ActualAnswersPosition)
            Case 9
                ValidationAnswer(RadioButtonListQuestionNine, ActualAnswersPosition)
            Case 10
                ValidationAnswer(RadioButtonListQuestionTen, ActualAnswersPosition)
        End Select
    End Sub

    Private Sub ValidationAnswer(RadioButtonList As RadioButtonList, ActualAnswersPosition As Integer)
        Const CorrectAnswerValue = 1
        AnswersCounter = Convert.ToInt32(Session.Contents("AnswersCounter"))
        Session.Add("AnswersCounter", AnswersCounter)
        If RadioButtonList.SelectedValue = Answers(ActualAnswersPosition) Then
            AnswersCounter += CorrectAnswerValue
        End If
        Session.Add("AnswersCounter", AnswersCounter)
    End Sub

    Protected Sub ButtonRestartExam_Click(sender As Object, e As EventArgs) Handles ButtonRestartExam.Click
        RestartExam()
        SetVisibilityButtons(True)
    End Sub

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
        Const StepCount As Integer = 1
        Const TotalAnswersValue As Integer = 100
        Dim Answer As Integer
        For Answer = 1 To Answers.Length Step StepCount
            AddAnswer(Answer)
        Next Answer
        Dim TotalAnswers As Integer
        TotalAnswers = Answers.Length
        AnswersCounter = Convert.ToInt32(Session.Contents("AnswersCounter"))
        Dim PercentageAnswers = (AnswersCounter * TotalAnswersValue) / TotalAnswers
        SendMessage("Correct answers: " & AnswersCounter & " on: " & TotalAnswers & " Percentage: " & PercentageAnswers & "%")
    End Sub
End Class