#pragma checksum "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e58ad91aa0ebf54adf5e2da4e8c4d50a312f339"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Anasayfa_Index), @"mvc.1.0.view", @"/Views/Anasayfa/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\_ViewImports.cshtml"
using ParamEmrimde;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\_ViewImports.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\_ViewImports.cshtml"
using ParamEmrimde.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e58ad91aa0ebf54adf5e2da4e8c4d50a312f339", @"/Views/Anasayfa/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57a2ef2cdc45b507efbf12577cf76102de0b308d", @"/Views/_ViewImports.cshtml")]
    public class Views_Anasayfa_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_EklePartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
  
    ViewData["Title"] = "Anasayfa";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content-wrapper"">
    <div class=""row"">
        <div class=""col-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""row"">
                    <div class=""col-6 col-lg-3"">
                        <div class=""card-body"">
                            <h4 class=""card-title text-success"">Gelir</h4>
                            <p class=""display-5 text-success"">
                                ");
#nullable restore
#line 14 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                            Write((ViewBag.Gelir).ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                            </p>
                            <div class=""template-demo"">
                                <button type=""button"" class=""btn btn-success btn-icon-text btn-sm"" data-toggle=""modal"" href=""#addGelirModal"">
                                    <i class=""typcn typcn-plus btn-icon-prepend""></i>
                                    Ekle
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class=""col-6 col-lg-3"">
                        <div class=""card-body"">
                            <h4 class=""card-title text-warning"">Gider</h4>
                            <p class=""display-5 text-warning"">
                                ");
#nullable restore
#line 28 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                            Write((ViewBag.Gider).ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                            </p>
                            <div class=""template-demo"">
                                <button type=""button"" class=""btn btn-warning btn-icon-text btn-sm"" data-toggle=""modal"" href=""#addGiderModal"">
                                    <i class=""typcn typcn-plus btn-icon-prepend""></i>
                                    Ekle
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class=""col-6 col-lg-3"">
                        <div class=""card-body"">
                            <h4 class=""card-title text-info"">Tasarruf</h4>
                            <p class=""display-5 text-info"">
                                ");
#nullable restore
#line 42 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                            Write((ViewBag.Tasarruf).ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                            </p>
                            <div class=""template-demo"">
                                <button type=""button"" class=""btn btn-info btn-icon-text btn-sm"" data-toggle=""modal"" href=""#addTasarrufModal"">
                                    <i class=""typcn typcn-plus btn-icon-prepend""></i>
                                    Ekle
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class=""col-6 col-lg-3"">
                        <div class=""card-body"">
                            <h4 class=""card-title text-primary"">Borç</h4>
                            <p class=""display-5 text-primary"">
                                ");
#nullable restore
#line 56 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                            Write((ViewBag.Borc).ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                            </p>
                            <div class=""template-demo"">
                                <button type=""button"" class=""btn btn-primary btn-icon-text btn-sm"" data-toggle=""modal"" href=""#addBorcModal"">
                                    <i class=""typcn typcn-plus btn-icon-prepend""></i>
                                    Ekle
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card bg-secondary"">
                <div class=""card-body text-center"">
                    <h1 class=""text-white"">Kalan : ");
#nullable restore
#line 72 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                                               Write((ViewBag.Kalan).ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₺</h1>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-lg-12 grid-margin stretch-card\">\r\n");
#nullable restore
#line 77 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
             if (ViewData["tarihKucuk"] != null || ViewData["tarihBuyuk"] != null || ViewData["kategori"] != null || ViewData["name"] != null || ViewData["price"] != null || ViewData["kalem"] != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
           Write(await Component.InvokeAsync("KasaList", new { tarihKucuk = @ViewData["tarihKucuk"], tarihBuyuk = @ViewData["tarihBuyuk"], kategori = @ViewData["kategori"], name = @ViewData["name"], price = @ViewData["price"], kalem = @ViewData["kalem"] }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                                                                                                                                                                                                                                                                
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
           Write(await Component.InvokeAsync("KasaListTop"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Aydın\YandexDisk\WebCore\ParamEmrimde\ParamEmrimde\Views\Anasayfa\Index.cshtml"
                                                           
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <!-- Modal - gelir - Ekle -->\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e58ad91aa0ebf54adf5e2da4e8c4d50a312f33910896", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <!-- /#gelir-modal -->\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

            // Arama kutusu baş olduğunda işlem yapıyor
            $(""#filter"").submit(function () {
                $(this).find("":input"").filter(function () { return !this.value; }).attr(""disabled"", ""disabled"");
                return true;
            });
            $(""form"").find("":input"").prop(""disabled"", false)

            //Datatable biçimlendirdim
            $('#myTable').DataTable({
                ""lengthMenu"": [[25, 50, -1], [25, 50, ""Tümü""]],
                ""order"": [[0, ""desc""]],
                ""language"": { ""url"": ""https://cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"" }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#addGelirModal #sayisalinput"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
");
                WriteLiteral(@"            $(""#addGiderModal #sayisalinput"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#addTasarrufModal #sayisalinput"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#addBorcModal #sayisalinput"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#editGelirModal #kasaTutar"").keyup(function () {
                if (this.value.match(/[^0-9,.]/g)) {
                    this.value = this.value.replace(/[^0-9,.]/g, '');");
                WriteLiteral(@"
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#editGiderModal #kasaTutar"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#editTasarrufModal #kasaTutar"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });

            //Sadece sayı ve virgül girebilirsin
            $(""#editBorcModal #kasaTutar"").keyup(function () {
                if (this.value.match(/[^0-9,]/g)) {
                    this.value = this.value.replace(/[^0-9,]/g, '');
                }
            });


            // Activate tooltip
            $('[data-toggle=""tooltip""]').tooltip();

            $('table #delete').on('click', function () {
      ");
                WriteLiteral(@"          var id = $(this).parent().find('.id').val();
                $('#deleteGelirModal #id').val(id);
            });

            $('table #edit').on('click', function () {
                var kalemid = $(this).parent().find('.kalemid').val();
                $('#editGelirModal #kalemid').val(kalemid);
                $('#editGiderModal #kalemid').val(kalemid);
                $('#editTasarrufModal #kalemid').val(kalemid);
                $('#editBorcModal #kalemid').val(kalemid);

                var id = $(this).parent().find('.id').val();
                $.ajax({
                    type: 'GET',
                    url: '/Anasayfa/Getir/' + id,
                    success: function (getir) {
                        if (kalemid == 1) {
                            $('#editGelirModal #id').val(getir.kasaId);
                            $('#editGelirModal #kasaTarih').val(getir.kasaTarih);
                            $('#editGelirModal #katId').val(getir.katId);
                      ");
                WriteLiteral(@"      $('#editGelirModal #kasaTutar').val(getir.kasaTutar);
                            $('#editGelirModal #kasaAciklama').val(getir.kasaAciklama);
                        }
                        else if (kalemid == 2) {
                            $('#editGiderModal #id').val(getir.kasaId);
                            $('#editGiderModal #kasaTarih').val(getir.kasaTarih);
                            $('#editGiderModal #katId').val(getir.katId);
                            $('#editGiderModal #kasaTutar').val(getir.kasaTutar);
                            $('#editGiderModal #kasaAciklama').val(getir.kasaAciklama);
                        }
                        else if (kalemid == 3) {
                            $('#editTasarrufModal #id').val(getir.kasaId);
                            $('#editTasarrufModal #kasaTarih').val(getir.kasaTarih);
                            $('#editTasarrufModal #katId').val(getir.katId);
                            $('#editTasarrufModal #kasaTutar').val(getir.kasa");
                WriteLiteral(@"Tutar);
                            $('#editTasarrufModal #kasaAciklama').val(getir.kasaAciklama);
                        }
                        else if (kalemid == 4) {
                            $('#editBorcModal #id').val(getir.kasaId);
                            $('#editBorcModal #kasaTarih').val(getir.kasaTarih);
                            $('#editBorcModal #katId').val(getir.katId);
                            $('#editBorcModal #kasaTutar').val(getir.kasaTutar);
                            $('#editBorcModal #kasaAciklama').val(getir.kasaAciklama);
                        }
                    }
                });
            });

            $('table #ode').on('click', function () {
                var kalemid = $(this).parent().find('.kalemid').val();
                $('#odeBorcModal #kalemid').val(kalemid);

                var id = $(this).parent().find('.id').val();
                $.ajax({
                    type: 'GET',
                    url: '/Home/Getir/' + id,
 ");
                WriteLiteral(@"                   success: function (getir) {
                        $('#odeBorcModal #id').val(getir.kasaId);
                        $('#odeBorcModal #kasaTarih').val(getir.kasaTarih);
                        $('#odeBorcModal #katId').val(getir.katId);
                        $('#odeBorcModal #kasaTutar').val(getir.kasaTutar);
                        $('#odeBorcModal #kasaAciklama').val(getir.kasaAciklama);
                    }
                });
            });

        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
