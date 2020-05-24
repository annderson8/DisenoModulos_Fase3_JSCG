Public Class Questions
    Inherits System.Web.UI.Page

    Private ReadOnly Answers = New String() {"D", "A"}
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
        RadioButtonListQuestionOne.SelectedIndex = -1
        RadioButtonListQuestionTwo.SelectedIndex = -1
    End Sub

    Protected Sub ButtonNextQuestion_Click(sender As Object, e As EventArgs) Handles ButtonNextQuestion.Click
        Dim MaxViews = MultiViewPrincipal.Views.Count - 1
        If SelectedAnswer() Then
            If MultiViewPrincipal.ActiveViewIndex < MaxViews Then
                MultiViewPrincipal.ActiveViewIndex = MultiViewPrincipal.ActiveViewIndex + 1
            Else
                SetVisibilityButtons(False)
                MsgBox("Correct answers: " & AnswersCounter)
            End If
        End If
    End Sub

    Private Function SelectedAnswer() As Boolean
        SelectedAnswer = True
        Dim ActualView As Integer
        ActualView = MultiViewPrincipal.ActiveViewIndex + 1
        Select Case ActualView
            Case 1
                If RadioButtonListQuestionOne.SelectedIndex < 0 Then
                    MsgBox("In question: " & ActualView & " need to select an answer; cannot continue", MsgBoxStyle.OkOnly, "Error")
                    SelectedAnswer = False
                Else
                    AddAnswer(ActualView)
                End If
            Case 2
                If RadioButtonListQuestionTwo.SelectedIndex < 0 Then
                    MsgBox("In question: " & ActualView & " need to select an answer; cannot continue", MsgBoxStyle.OkOnly, "Error")
                    SelectedAnswer = False
                Else
                    AddAnswer(ActualView)
                End If
        End Select
    End Function

    Private Sub AddAnswer(ActualView As Integer)
        Dim ActualAnswersPosition As Integer
        ActualAnswersPosition = ActualView - 1
        AnswersCounter = Convert.ToInt32(Session.Contents("AnswersCounter"))
        Session.Add("AnswersCounter", AnswersCounter)
        Select Case ActualView
            Case 1
                If RadioButtonListQuestionOne.SelectedValue = Answers(ActualAnswersPosition) Then
                    AnswersCounter += 1
                End If
            Case 2
                If RadioButtonListQuestionTwo.SelectedValue = Answers(ActualAnswersPosition) Then
                    AnswersCounter += 1
                End If
        End Select
        Session.Add("AnswersCounter", AnswersCounter)
    End Sub

    Protected Sub ButtonRestartExam_Click(sender As Object, e As EventArgs) Handles ButtonRestartExam.Click
        If MsgBox("You want to restart the exam?, this affects the selected answers.", vbYesNo, "Attention") = MsgBoxResult.Yes Then
            RestartExam()
            SetVisibilityButtons(True)
        End If
    End Sub
End Class