﻿namespace Project04_ConvertTypes;

class Program
{
    static void Main(string[] args)
    {
        #region Imlicit Convertc(Örtülü dönüştürme)
        /*
         int myAge=49;
         long newMyAge=myAge; // int to long


         float rate=0.87f; //float ondalıklı sayı
         double newRate=rate; // float to double
         

         byte studentNote=75;
         int newStudentNote=studentNote; // byte to int 
         */




        #endregion



        #region Explicit Convert(Açık dönüştürme)--- Bu işlemde veri kaybı olabilir.
        double myValue = 123.58;
        int newMyValue = (int)myValue;// 


        #endregion
    }
}
