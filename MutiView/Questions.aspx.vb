Public Class Questions
    Inherits System.Web.UI.Page

    Private ReadOnly Answers = New String() {"D", "A", "C", "B", "D", "B", "C", "A", "D", "C"}
    Private Property AnswersCounter As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RestartExam()
            SetVisibilityButtons(True)
        End If
    End Sub

    Private Sub SetVisibilityButtons(Visibility As Boolean)
        ButtonNextQuestion.Visible = Visibility
        ButtonRestartExam.Visible = Not Visibility
    End Sub

    Private Sub RestartExam()
        MultiViewPrincipal.SetActiveView(ViewQuestionOne)
        AnswersCounter = 0
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
        RadioButtonList.SelectedIndex = -1
    End Sub

    Protected Sub ButtonNextQuestion_Click(sender As Object, e As EventArgs) Handles ButtonNextQuestion.Click
        Dim MaxViews = MultiViewPrincipal.Views.Count - 1
        If SelectedAnswer() Then
            If MultiViewPrincipal.ActiveViewIndex < MaxViews Then
                MultiViewPrincipal.ActiveViewIndex = MultiViewPrincipal.ActiveViewIndex + 1
            Else
                SetVisibilityButtons(False)
                Dim TotalAnswers As Integer
                TotalAnswers = Answers.Length
                Dim PercentageAnswers = (TotalAnswers * 100) / AnswersCounter
                SendMessage("Correct answers: " & AnswersCounter & " on: " & TotalAnswers & " Percentage: %" & PercentageAnswers)
            End If
        End If
    End Sub

    Private Function SelectedAnswer() As Boolean
        Dim ActualView As Integer
        ActualView = MultiViewPrincipal.ActiveViewIndex + 1
        Dim MessageValidation As String
        MessageValidation = "In question: " & ActualView & " need to select an answer; cannot continue"
        Select Case ActualView
            Case 1
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionOne, MessageValidation, ActualView)
            Case 2
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionTwo, MessageValidation, ActualView)
            Case 3
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionThree, MessageValidation, ActualView)
            Case 4
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionFour, MessageValidation, ActualView)
            Case 5
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionFive, MessageValidation, ActualView)
            Case 6
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionSix, MessageValidation, ActualView)
            Case 7
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionSeven, MessageValidation, ActualView)
            Case 8
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionEight, MessageValidation, ActualView)
            Case 9
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionNine, MessageValidation, ActualView)
            Case 10
                SelectedAnswer = ValidateSelectedAnswer(RadioButtonListQuestionTen, MessageValidation, ActualView)
            Case Else
                SelectedAnswer = False
        End Select
    End Function

    Private Function ValidateSelectedAnswer(RadioButtonList As RadioButtonList, MessageValidation As String, ActualView As Integer)
        If RadioButtonList.SelectedIndex < 0 Then
            SendMessage(MessageValidation)
            ValidateSelectedAnswer = False
        Else
            AddAnswer(ActualView)
            ValidateSelectedAnswer = True
        End If
    End Function

    Private Sub AddAnswer(ActualView As Integer)
        Dim ActualAnswersPosition As Integer
        ActualAnswersPosition = ActualView - 1
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
        AnswersCounter = Convert.ToInt32(Session.Contents("AnswersCounter"))
        Session.Add("AnswersCounter", AnswersCounter)
        If RadioButtonList.SelectedValue = Answers(ActualAnswersPosition) Then
            AnswersCounter += 1
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

End Class