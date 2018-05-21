using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentReader documenteReader = new PDFDocument();
            documenteReader.OpenDocument();

            Console.WriteLine();

            documenteReader = new WordDocument();
            documenteReader.OpenDocument();

            Console.ReadKey();
        }
    }

    abstract class DocumentReader
    {
        public void LoadFile()
        {
            Console.WriteLine("Document File loaded");
        }

        public abstract void InterpretDocumentFormat();

        public void Open()
        {
            Console.WriteLine("Document File opens");
        }

        //Template Method
        public void OpenDocument()
        {
            LoadFile();
            InterpretDocumentFormat();
            Open();
        }

    }

    class PDFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +  "PDF Interpreter");
        }
    }

    class WordDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " + "Word Interpreter");
        }
    }
}