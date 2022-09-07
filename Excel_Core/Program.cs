// See https://aka.ms/new-console-template for more information
using Excel_Core.Model;
using ExcelMapper;

string fileLocation = "C:\\Users\\USER\\Downloads\\Ex_SPDV.xlsx";
var stream = File.OpenRead(fileLocation);
var importer = new ExcelImporter(stream);
ExcelSheet sheet = importer.ReadSheet();
SPDV[] spdvs = sheet.ReadRows<SPDV>().ToArray();
Console.WriteLine(spdvs);




