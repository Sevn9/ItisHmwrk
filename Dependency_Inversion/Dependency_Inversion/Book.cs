using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Inversion
{
  class Book
  {
    public string Text { get; set; }
    public IPrinter Printer { get; set; }

    public Book(IPrinter printer)
    {
      this.Printer = printer;
    }

    public void Print()
    {
      Printer.Print(Text);
    }
  }
  class ConsolePrinter : IPrinter
  {
    public void Print(string text)
    {
      Console.WriteLine("Печать на консоли");
    }
  }

  class HtmlPrinter : IPrinter
  {
    public void Print(string text)
    {
      Console.WriteLine("Печать в html");
    }
  }
}
