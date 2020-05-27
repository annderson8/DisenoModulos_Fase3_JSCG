Public Class SeeAnswers
    Inherits System.Web.UI.Page

#Region "Variables or constants"

    Private Property AnswersCounter As Integer

#End Region

#Region "Events"

    ''' <summary>
    ''' Initial page event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Const StartPosition As Integer = 0
            AnswersCounter = 0
            Dim Answers() As String = Session.Contents("Answers")
            Dim SelectedAnswers() As String = Session.Contents("SelectedAnswers")
            Dim DataTableAnswers As New DataTable()
            DataTableAnswers.Columns.Add("Question")
            DataTableAnswers.Columns.Add("Selected Answer")
            DataTableAnswers.Columns.Add("Correct Answer")
            DataTableAnswers.Columns.Add("Value")
            For i = StartPosition To Answers.Length - 1
                Dim DataRowAnswer As DataRow = DataTableAnswers.NewRow()
                DataRowAnswer("Question") = i + 1
                DataRowAnswer("Selected Answer") = SelectedAnswers(i)
                DataRowAnswer("Correct Answer") = Answers(i)
                DataRowAnswer("Value") = GetValueAnswer(SelectedAnswers(i), Answers(i))
                DataTableAnswers.Rows.Add(DataRowAnswer)
            Next
            GridViewSeeAnswers.Visible = True
            GridViewSeeAnswers.DataSource = DataTableAnswers
            GridViewSeeAnswers.DataBind()
            Dim TotalAnswers As Integer
            TotalAnswers = Answers.Length
            Const TotalAnswersValue As Integer = 100
            Dim PercentageAnswers = (AnswersCounter * TotalAnswersValue) / TotalAnswers
            LabelResult.Text = "Correct answers: " & AnswersCounter & " on: " & TotalAnswers & " Percentage: " & PercentageAnswers & "%"
        End If
    End Sub

    ''' <summary>
    ''' Restart Exam button event question
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonRestartExam_Click(sender As Object, e As EventArgs) Handles ButtonRestartExam.Click
        Response.Redirect("Questions.aspx")
    End Sub

#End Region

#Region "Methods and functions"

    ''' <summary>
    ''' Function that compares the answer selected by the user against the correct answer
    ''' </summary>
    ''' <param name="SelectedAnswer">User selected answer</param>
    ''' <param name="CorrectAnswer">Correct answer</param>
    ''' <returns>Integer value specifying the score received by the user</returns>
    Private Function GetValueAnswer(ByVal SelectedAnswer As String, ByVal CorrectAnswer As String) As Integer
        Const ValueCorrectAnswer As Integer = 1
        Const ValueIncorrectAnswer As Integer = 0
        If SelectedAnswer.Equals(CorrectAnswer) Then
            GetValueAnswer = ValueCorrectAnswer
            AnswersCounter += ValueCorrectAnswer
        Else
            GetValueAnswer = ValueIncorrectAnswer
        End If
    End Function

#End Region

End Class