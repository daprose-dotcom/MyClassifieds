Imports System.Configuration
Imports System.Data.SqlClient
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

            Dim strSelect As String = "SELECT * FROM [Countries] WHERE [IsActive] = 1 ORDER BY [name] DESC"

            Session("Pais") = ""

            Using con As New SqlConnection(constr)

                Using cmd As New SqlCommand(strSelect)
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    ddlpaises.DataSource = cmd.ExecuteReader()
                    ddlpaises.DataTextField = "name"
                    ddlpaises.DataValueField = "country3"
                    ddlpaises.DataBind()
                    con.Close()
                End Using
            End Using
            ddlpaises.Items.Insert(0, New ListItem("-- Select a Country --", "NON"))

        Else

            Dim strPaisSelected As String = ddlpaises.SelectedValue.Trim
            Dim strEstadoSelected As String = ddlestado.SelectedValue.Trim
            Dim strCiudadSelected As String = ddlciudad.SelectedValue.Trim
            Dim strCategorySelected As String = ddlcat.SelectedValue.Trim
            Dim strSubCategorySelected As String = ddlsubcat.SelectedValue.Trim

            If strPaisSelected <> Session("Pais") Then

                If strPaisSelected <> "" And strPaisSelected <> "--" Then

                    ddlestado.Visible = True

                    Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

                    Dim strSelect As String = "SELECT DISTINCT [CiudadDistrito],[PaisCodigo] FROM [States] WHERE [PaisCodigo] = '" & strPaisSelected & "' ORDER BY [CiudadDistrito],[PaisCodigo];"
                    Using con As New SqlConnection(constr)

                        Using cmd As New SqlCommand(strSelect)
                            cmd.CommandType = CommandType.Text
                            cmd.Connection = con
                            con.Open()
                            ddlestado.Items.Clear()
                            ddlestado.DataSource = cmd.ExecuteReader()
                            ddlestado.DataTextField = "CiudadDistrito"
                            ddlestado.DataValueField = "CiudadDistrito"
                            ddlestado.DataBind()
                            con.Close()
                        End Using
                    End Using

                    ddlestado.Items.Insert(0, New ListItem("-- State or Province --", "NON"))
                    Session("Pais") = ddlpaises.SelectedValue.Trim
                    btnSubmit.Visible = False


                End If

            Else

                If strEstadoSelected <> Session("Estado") Then

                    If strEstadoSelected <> "" And strEstadoSelected <> "--" Then

                        ddlciudad.Visible = True

                        Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

                        Dim strSelect As String = "SELECT * FROM [Ciudades] WHERE [PaisCodigo] = '" & strPaisSelected & "' AND [CiudadDistrito] = '" & strEstadoSelected & "' ORDER BY [PaisCodigo], [CiudadDistrito], [CiudadNombre]"
                        Using con As New SqlConnection(constr)

                            Using cmd As New SqlCommand(strSelect)
                                cmd.CommandType = CommandType.Text
                                cmd.Connection = con
                                con.Open()
                                ddlciudad.DataSource = cmd.ExecuteReader()
                                ddlciudad.DataTextField = "CiudadNombre"
                                ddlciudad.DataValueField = "CiudadID"
                                ddlciudad.DataBind()
                                con.Close()
                            End Using
                        End Using

                        ddlciudad.Items.Insert(0, New ListItem("-- Select a City --", "0"))
                        Session("Estado") = ddlestado.SelectedValue.Trim
                        btnSubmit.Visible = False

                    End If
                Else

                    If strCiudadSelected <> Session("Ciudad") Then

                        If strCiudadSelected <> "" And strCiudadSelected <> "--" Then

                            ddlcat.Visible = True

                            Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

                            Dim strSelect As String = "SELECT * FROM [Categories] WHERE [Category_Parent] = 0 ORDER BY [Category_Parent], [Category_Name]"
                            Using con As New SqlConnection(constr)

                                Using cmd As New SqlCommand(strSelect)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Connection = con
                                    con.Open()
                                    ddlcat.DataSource = cmd.ExecuteReader()
                                    ddlcat.DataTextField = "Category_Name"
                                    ddlcat.DataValueField = "Category_ID"
                                    ddlcat.DataBind()
                                    con.Close()
                                End Using
                            End Using

                            ddlcat.Items.Insert(0, New ListItem("-- Select Category --", "--"))
                            Session("Ciudad") = ddlciudad.SelectedValue.Trim
                            btnSubmit.Visible = False

                        End If


                    Else

                        If strCategorySelected <> Session("Category") Then

                            If strCategorySelected <> "" And strCategorySelected <> "--" Then

                                ddlsubcat.Visible = True

                                Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
                                Dim strSelect As String = "SELECT * FROM [Categories] WHERE [Category_Parent] = " & strCategorySelected & " ORDER BY [Category_Parent], [Category_Name]"
                                Using con As New SqlConnection(constr)

                                    Using cmd As New SqlCommand(strSelect)
                                        cmd.CommandType = CommandType.Text
                                        cmd.Connection = con
                                        con.Open()
                                        ddlsubcat.DataSource = cmd.ExecuteReader()
                                        ddlsubcat.DataTextField = "Category_Name"
                                        ddlsubcat.DataValueField = "Category_ID"
                                        ddlsubcat.DataBind()
                                        con.Close()
                                    End Using
                                End Using

                                ddlsubcat.Items.Insert(0, New ListItem("-- Select Subcategory --", "--"))
                                Session("Category") = ddlcat.SelectedValue.Trim
                                btnSubmit.Visible = False

                            End If

                        Else

                            If strSubCategorySelected <> Session("SubCat") Then

                                If strSubCategorySelected <> "" And strSubCategorySelected <> "--" Then

                                    Session("SubCat") = ddlsubcat.SelectedValue.Trim
                                    btnSubmit.Visible = True

                                End If

                            Else

                                Dim strSubmit As String = Request.Form("btnSubmit")

                                If strSubmit <> "Submit" Then

                                    '## Publish the Results Here
                                    'labelListResults.Visible = True
                                    'GridViewTitle.Visible = True

                                    Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
                                    Dim strSelect As String = "SELECT [ID],[Title] FROM [Ads] WHERE [CityID] = " & strCiudadSelected & " AND [CategoryID] = " & strSubCategorySelected & " AND IsActive = 1 ORDER BY [PostDate] DESC"
                                    Using con As New SqlConnection(constr)
                                        Using cmd As New SqlCommand(strSelect)
                                            cmd.CommandType = CommandType.Text
                                            cmd.Connection = con
                                            con.Open()
                                            'GridViewTitle.DataSource = cmd.ExecuteReader()
                                            'GridViewTitle.DataBind()
                                            con.Close()
                                        End Using
                                    End Using

                                    'GridViewTitle.iInsert(0, New ListItem("-- Selecciona una subcategoría --", "--"))

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
End Class