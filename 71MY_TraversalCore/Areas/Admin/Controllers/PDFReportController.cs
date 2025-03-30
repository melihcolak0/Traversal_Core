using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReporst/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/PdfReporst/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }       
    }
}
