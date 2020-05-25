<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Questions.aspx.vb" Inherits="MutiView.Questions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Questions</title>
</head>
<body>
	<form id="formQuestions" runat="server">
		<div>
			<asp:MultiView ID="MultiViewPrincipal" runat="server">
				<asp:View ID="ViewQuestionOne" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question One</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>1.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
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
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Two</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>2.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
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
				<asp:View ID="ViewQuestionThree" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Three</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>3.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>3. What is the extension of ASP.NET files?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionThree" runat="server">
								<asp:ListItem Text="A. .ASP." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. .JSP." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. .ASPX." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. .HTML." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionFour" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Four</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>4.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>4. ASP.NET can be distributed on another server other than Internet Information Services, (IIS)?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionFour" runat="server">
								<asp:ListItem Text="A. IIS." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. APACHE." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. TOMCAT." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. WEB LOGIC." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionFive" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Five</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>5.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>5. In the code-behind model, the dynamic code of a web page is stored in which file?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionFive" runat="server">
								<asp:ListItem Text="A. .JAVA." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. .DFM." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. .ASP/ASPX." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. VB/CS." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionSix" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Six</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>6.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>6. In what year is the first beta and the first demo of ASP.NET presented?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionSix" runat="server">
								<asp:ListItem Text="A. 1999." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. 2000." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. 2001." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. 2003." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionSeven" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Seven</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>7.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>7. ASP.NET which technology replaces?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionSeven" runat="server">
								<asp:ListItem Text="A. JSP." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. DOCKER." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. ASP." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. JS." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionEight" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Eight</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>8.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>8. Which file allows you to configure the configuration options for a WEB application in ASP.NET?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionEight" runat="server">
								<asp:ListItem Text="A. WEB.CONFIG." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. APPLICATION.CONFIG." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. CONFIG.PROPERTIES." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. .INI." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionNine" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Nine</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>9.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>9. What is the first event that is executed when entering a page of type ASP.NET?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionNine" runat="server">
								<asp:ListItem Text="A. OnLoad." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. Page/Show." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. ButtonNextQuestion_Click." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. Page_Load." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
				<asp:View ID="ViewQuestionTen" runat="server">
					<div style="text-align: center; font-weight: bold; border: 3px solid black; width: auto;">Question Ten</div>
					<div style="float: left; width: 10%; border: 3px solid black; height: 120px;">
						<div style="text-align: center; width: 100%; height: 50%;">
							<h1>10.</h1>
						</div>
						<div style="text-align: right; width: 100%; height: 50%;">
							<h6>Rate 1 out of 1 &nbsp;</h6>
						</div>
					</div>
					<div style="float: initial; width: auto; border: 3px solid black; height: 120px;">
						<div>10. What reserved word is used to declare a variable in ASP.NET Visual Basic?</div>
						<div>
							<asp:RadioButtonList ID="RadioButtonListQuestionTen" runat="server">
								<asp:ListItem Text="A. Trim." Value="A"></asp:ListItem>
								<asp:ListItem Text="B. Set." Value="B"></asp:ListItem>
								<asp:ListItem Text="C. Dim." Value="C"></asp:ListItem>
								<asp:ListItem Text="D. Get." Value="D"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
				</asp:View>
			</asp:MultiView>
		</div>
		&nbsp;
		<div>
			<asp:Button ID="ButtonPreviousQuestion" runat="server" Visible="false" Text="Previous Question" />
			&nbsp;
			<asp:Button ID="ButtonNextQuestion" runat="server" Visible="false" Text="Next Question" />
			<asp:Button ID="ButtonNextEndExam" runat="server" Visible="false" Text="End Exam" OnClientClick="return confirm('You are sure?, at the end of the exam the selected answers are verified')" />
		</div>
	</form>
</body>
</html>
