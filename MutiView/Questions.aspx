<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Questions.aspx.vb" Inherits="MutiView.Questions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Questions</title>
</head>
<body>
	<form id="form" runat="server">
		<div>
			<asp:MultiView ID="MultiViewPrincipal" runat="server">
				<asp:View ID="ViewQuestionOne" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black;">Question One</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>1.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: 99.7; border: 3px solid black; height: 120px;">
						<div>1. What technology is ASP.NET built on?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionOne" runat="server">
								<asp:ListItem Text="A. .NET Framework." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. Active Server Pages (ASP)." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. Microsoft." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. Common Language Runtime." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionTwo" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black;">Question Two</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>2.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: 99.7; border: 3px solid black; height: 120px;">
						<div>2. As the ASP pages are officially called. NET?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionTwo" runat="server">
								<asp:ListItem Text="A. Web Forms." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. Forms." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. Visual Forms." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. Core Forms." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
			</asp:MultiView>
		</div>
		&nbsp;
		<div>
			<asp:Button ID="ButtonNextQuestion" runat="server" Visible="false" Text="Next Question" />
			&nbsp;
			<asp:Button ID="ButtonRestartExam" runat="server" Visible="false" Text="Restart Exam" />
		</div>
	</form>
</body>
</html>
