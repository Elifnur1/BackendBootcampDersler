﻿/*
Collections:C# içerisinde dizi benzeri bir veri yapısı ifade eder.Bir kaç türü vardır.

1)IEnemureble: En temel collections yapılarından biridir.Ve şu özelliklere sahiptir;
               *Iteration sağlar(döngü kullanabilme)
               *Verilerin sadece OKUNMASI GEREKEN durumlarda tercih edilir.
               *Bu durumda ekleme silme gibi operasyonalra izin vermez.
               *Özellikle for each döngüsü ile kullanmaya oldukça uygundur.
               *Verileri bellleğe almadan işlem yapar.
*/
// List<string>names=new List<string>{"Ali","Veli","Sezen","Murat"};
// IEnumerable<string>enumarableNames=names;
// foreach (var name in enumarableNames)
// {
//     System.Console.WriteLine(name);
// }

/*
2)ICollection:IEnumarable'dan türetilmiştir.Ek olarak şu özelliklere sahiptir:
              *Veri ekleme ve silme operasyonlarını destekler.
              *Eleman sayısını öğrenme imkanı sağlar,
              *Veri üzerinde iteration yaparken manipülasyon yapma ihtiyacı olan duurmlarda tercih edilir.
*/
// ICollection<string>names=new List<string>{"Ali","Veli","Sezen","Murat"};
// System.Console.WriteLine(names.Count);

/*
3)IList:ICollection'dan türetilmiştir.Ek olarak sahip olduğu özellikler:,
        *Indeksleme imkanı sunar.Bu sayede collection elemanlarına bir index numarası ile erişilebilir.([])
        *Sıralı veri yapılarında tercih edilebilir.
*/
// IList<string>names=new List<string>{"Ali","Veli","Sezen","Murat"};
// System.Console.WriteLine(names[0]);


/*
4)IQuerable:Bu collection yapısı biraz daha özel amaçlara hizmet eder:
           *Daha çok veri tabanı sorguları oluşturmak için tercih edilir.
           *Sorguyu,veri tabanına göndermeden önce optimize 
           *Büyük veri setlerinde çok ciddi bir peformans sağlar.
           *Filtreleme operasyonlarını direkt olarak veri tabanı üzerinde yaparak,hız kazandırır.
*/
//IEnumerable verileri belleğe çeker filtreleri orada yapar.Bellek daha hızlı yaptığı için oldukça performansı yüksek bir işlemdir.Her veriyi belleğe çekme işlemi yapmamayı tercih ederiz çünkü yer kaplamasını her seferinde istemeyiz.

//Kendi Örneklerim
// List<string>isimler=new List<string>{"Elif","Aleyna","Tuba","Berat"};IEnumerable<string>name=isimler;
// foreach (var x in name)
// {
//     System.Console.WriteLine(x);
// }
// List<string>names=new List<string>{"Ali","Veli","Zeki","Fadime"};
// ICollection<string>collectionNames=names;
// System.Console.WriteLine("Eleman sayısını öğrenme:" + collectionNames.Count);
// //Veri Ekleme
// collectionNames.Add("Nazan");
// System.Console.WriteLine("Yeni eleman eklenmiş haliyle:");
// foreach (var x in collectionNames)
// {
//     System.Console.WriteLine(x);
// }
// //Veri Silme;
// collectionNames.Remove("Ali");
// foreach (var x in collectionNames)
// {
//     System.Console.WriteLine(x);
// }
// IList<string>names=new List<string>{"Ali","Ayşe","Fatma","Kadir"};
// //İNDEKS NO İLE ERİŞİM;
// System.Console.WriteLine("0.İsim:" + names[0]);
// System.Console.WriteLine("1.İsim:" + names[1]);
// names.Add("Ezgi");
// foreach (var name in names)
// {
//     System.Console.WriteLine(name);
// }
List<string> names = new List<string> { "TUBA", "FATMA", "SEZER" };
IQueryable<string> QueryName = names.AsQueryable()
.Where(x => x.StartsWith("T"));
foreach (var name in QueryName)
{
        System.Console.WriteLine(name);
}
