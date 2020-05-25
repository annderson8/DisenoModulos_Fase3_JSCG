<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SeeAnswers.aspx.vb" Inherits="MutiView.SeeAnswers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="formSeeAnswers" runat="server">
		<div>
			<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">See Answers</div>
			<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">
				&nbsp;
				<asp:GridView ID="GridViewSeeAnswers" runat="server" HorizontalAlign="Center"></asp:GridView>
				<br />
				<asp:Label ID="LabelResult" runat="server"></asp:Label>
			</div>
			<br />
			<asp:Button ID="ButtonRestartExam" runat="server" Visible="true" Text="Restart Exam" OnClientClick="return confirm('You want to restart the exam?, this affects the selected answers.')" />
		</div>
	</form>
</body>
</html>
