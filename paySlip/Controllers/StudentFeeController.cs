using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using paySlip.Data;

public class StudentFeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentFeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var students = _context.StudentFees.ToList();
        return View(students);
    }

    public IActionResult DownloadPdf()
    {
        var students = _context.StudentFees.ToList();

        using (MemoryStream stream = new MemoryStream())
        {
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Add Title
            document.Add(new Paragraph("Student Semester Fee Details")
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20)
            );

            // Loop through each student and format details row-wise
            foreach (var student in students)
            {
                document.Add(new Paragraph($"Student ID: {student.StudentId}"));
                document.Add(new Paragraph($"Name: {student.Name}"));
                document.Add(new Paragraph($"Department: {student.Department}"));
                document.Add(new Paragraph($"Course: {student.Course}"));
                document.Add(new Paragraph($"Semester: {student.Semester}"));
                document.Add(new Paragraph($"Amount Paid: {student.AmountPaid:C}"));
                document.Add(new Paragraph($"Total Fee: {student.TotalFee:C}"));
                document.Add(new Paragraph($"Payment Date: {student.PaymentDate:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Payment Method: {student.PaymentMethod}"));
                document.Add(new Paragraph($"Transaction ID: {student.TransactionId}"));

                // Add spacing for better readability
                document.Add(new Paragraph("--------------------------------------------------")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(10)
                );
            }

            document.Close();
            pdf.Close();
            writer.Close();

            return File(stream.ToArray(), "application/pdf", "StudentFees.pdf");
        }
    }

}
