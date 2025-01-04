using System.Reflection;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Register.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        var stream = ReadFontFile(faceName) ?? ReadFontFile(FontHelper.DEFAULT_FONT);

        var length = (int)stream!.Length;
        
        var data = new byte[length];
        
        stream.Read(buffer: data, 0, length);

        return data;
    }
    
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        new Font
        {
            Name = FontHelper.RALEWAY_REGULAR,
        };
        
        return new FontResolverInfo(familyName);
    }

    private Stream? ReadFontFile(string faceName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts.{faceName}.ttf");
    }
}