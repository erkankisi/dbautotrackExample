using System;
using System.Drawing;
using System.IO;
using System.Xml;
using dbAutoTrack.PDFWriter;
using dbAutoTrack.PDFWriter.Graphics;

namespace PdfDokum
{
    public class Program
    {
        private PDFFont _normalFont;

        static void Main(string[] args)
        {
            string text = yazi();
            FileStream stream;
            stream = new FileStream("PdfExample.pdf", FileMode.Create, FileAccess.Write);

           // Image image = Image.FromFile("D:\\PdfDokum\\PdfDokum\\PdfDokum\\resim.png");
            dbAutoTrack.PDFWriter.Page page1 = new Page(PageSize.A4);
            Document document = new Document();
            document.SetSinglePassWriter(stream);
            document.LicenseKey = "37OJWP-ZDBKPY-G3ABOU-ZRY36Z-IC6IE";
            Page page = new Page(PageSize.A4);
            for (int i = 0; i < 3; i++)
            {
                Table tablo = new Table(pdfTabloStyleOlustur()) { CellPadding = 0 };
                //Row tabloSatir = new Row(tablo, pdfTabloStyleOlustur());
                tablo.Columns.Add(530);
                Row tabloSatir = new Row(tablo, pdfTabloStyleOlustur());

                tabloSatir.Cells.Add(text);
                tablo.Rows.Add(tabloSatir);
                while (tablo != null)
                {
                    var graphics = page.Graphics;
                    tablo = graphics.DrawTable(50, 75, 700, tablo);
                    document.Pages.Add(page);
                }
            } 
            //graphics.DrawImage(image, 50, 75, 250, 265, SizeMode.Stretch, new Border(0, PDFColor.White, LineStyle.Solid));
            document.Close();
            stream.Flush();
            stream.Close();
            Console.WriteLine("Pdf dosyası bin klosörüne çıkarıldı");
            Console.ReadKey();
        }

        public static TableStyle pdfTabloStyleOlustur()
        {
            int tabloFontSize = 8;
            var font1 = new Font("Arial", 10, FontStyle.Bold);
            var pdffont = new PDFFont(font1, false);
            TextAlignment textAlignment = TextAlignment.Justify;
            Border tabloBorder = new Border(0.0f, RGBColor.White, (LineStyle)Enum.Parse(typeof(LineStyle), "Solid"));
            TableStyle tableStyle = new TableStyle(pdffont, tabloFontSize, PDFColor.Black, textAlignment, ContentAlignment.TopLeft, true, RGBColor.Transparent, tabloBorder, false);
            return tableStyle;
        }
        public static string yazi()
        {
            return @"AÇIKLAMALAR VE ÖZEL KOŞULLAR  Rizikonun 60 günden fazla süre ile boş kalması durumunda poliçe teminatları ancak aşağıda yazılı güvenlik önlemlerinden en az birinin bulunması kaydı ile geçerlidir.
   - Rizikoda 24 saat güvenlik görevlisi veya bekçi bulunması
- Profesyonel güvenlik firmasına bağlı alarm ve kamera sistemi bulunması
Bu önlemlerin bulunmaması durumunda her bir hasarda (Deprem, Sel ve Su Baskını, Terör hasarları hariç) sigorta bedeli üzerinden % 10, minimum 50.000 TL tenzili muafiyet uygulanacaktır.
Bu poliçe kapsamında verilen teminatlar ile ilgili olarak sigortalının aynı zamanda Ana Sigorta tarafından düzenlenmiş birden fazla poliçesi var ise; tanzim edilen ilk poliçe önce devreye girecektir. İlgili poliçenin  teminat limitinin yeterli olmadığı durumlarda, ilk tanzim edilen poliçenin üzerinden kalan tazminat tutarı için, daha sonra tanzim edilen poliçelerin teminat limitleri tanzim tarihi sırasına göre geçerli olacaktır.
Sigortalı riziko adresi dışında bulunan iletim ve/veya dağıtım hatlarında oluşabilecek her türlü doğrudan ve dolaylı hasar teminat haricidir. İş bu poliçede teminat kapsamına alınmışsa Makine Kırılması ve Elektronik Cihaz teminatları için riziko sınırları içinde ve dışında iletim ve/veya dağıtım hatlarında oluşabilecek her türlü doğrudan veya dolaylı hasar teminat haricidir.
İş bu poliçede sağlanan sorumluluk teminatlarıyla ilgili olarak meydana gelebilecek olan hasarlar, öncelikle sigorta konusu ile ilgili yaptırılması yasal olarak zorunlu olan sigortalardan karşılanacaktır.
Zorunlu sigorta sözleşmesinin hiç yapılmamış olması, yapılmış fakat geçersiz hale gelmiş olması, süresinin bitmiş olması veya meydana gelen zararın bu sigorta teminatlarının üzerinde bulunması halinde, zorunlu teminatların üzerinde kalan kısım için iş bu poliçe limitleri devreye girecektir.
- Riziko binasına sabitlenmiş televizyon- radyo antenleri, gün ısılar, klima motorları, ışıklandırma sistemleri, paratoner, tente vb. kıymetler ile riziko adresinde bulunan tabela ve totemler demirbaş tanımına dahildir. Dolu, Kar Ağırlığı, Sel/Su Baskını ve Hırsızlık risklerine karşı teminat kapsamı dışındadır. Yangın Sigortası Genel Şartları saklı kalmak kaydıyla fırtına hasarlarında bu kıymetler 250 TL'den az olmamak üzere hasarın %10'u oranında tenzili muafiyet uygulanacaktır.
- İnşaat/Montaj hasarları, İnşaat/Montaj kapsamındaki Bakım ve/veya Test hasarları ve bunlardan kaynaklanabilecek her türlü hasar teminat haricidir. Arızi İnşaat teminatı tanımı içine giren çalışmalar Arızi İnşaat kloz kapsamında değerlendirilecektir.
Deprem ve yanardağ püskürmesi sigortası, %100 sigorta bedelinin Muhteviyat için %20' sinin sigortalı üzerinde kalması ve meydana gelecek hasarlarda sigortalının bu oranlarda hasara iştirak etmesi kaydıyla sigortalı ile müşterek sigorta şeklinde yapılmıştır. Sigortalı ve sigortacı bu oranın artırılması hususunda anlaşabilirler. Bu durumda prim, % 100 sigorta bedeli üzerinden, tarifede belirtilen fiyat indirimi esas alınarak hesaplanır. Bu husus poliçenin ön yüzüne yazılır. 
Sigortalı sigorta bedelinden kendi üzerinde kabul ve taahhüt ettiği kısmı tekrar sigorta ettiremez. Sigortalı meydana gelecek hasarlarda önceden mutabık kalınan ve poliçede yazılan oranla hasara iştirak eder. 
Deprem ve yanardağ püskürmesi teminatı ile ilgili her bir hasarda, aynı sigortalıya ait ve aynı riziko 
adresindeki sigorta teminatının muhteviyatı (emtia; makine, teçhizat, demirbaş ve diğer tesisat) veya 
birden fazla muhteviyatı kapsaması halinde bilumum; Emtia, Makine, teçhizat, demirbaş ve diğer tesisat gruplarının her birinin toplam sigorta bedelleri 
(sigortacının sorumlu olduğu kısım) üzerinden %2 oranında bulunacak bir tenzili muafiyet bu grupların her biri için ayrı ayrı uygulanır. 
Sigortacı, hasarın bu muafiyet miktarını aşan kısmından sorumludur. Sigortalı ve sigortacı, muafiyet 
oranının artırılması hususunda anlaşabilirler. Bu durumda fiyattan, tarifede belirtilen oranda indirim yapılır. Bu husus poliçenin ön yüzüne yazılır. 
Muafiyet uygulaması açısından, her bir 72 saatlik dönem bir hasar sayılır.Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.
Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.
Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.
Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.
Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.Poliçede temin edilen tehlikelerin gerçekleşmesi sonucunda (Deprem ve Y.P. riski hariç) sigortalı binanın kullanılamaz hale gelmesi nedeni ile sigortalı iş yerinin tamiri veya yeniden inşası için azami 6 (altı) ayı geçmeyecek şekilde sigortalının kiracı veya şagil veya malik sıfatı ile alternatif, geçici nitelikteki bir iş yeri için yapacağı makul ölçüdeki masraflar poliçe üzerinde belirtilen sigorta bedeli ile teminata dahil edilmiştir. Sigortacının azami sorumluluğu toplam sigorta bedelinin %10 (on)unu geçemeyecek olup azami poliçede belirtilen tutar ile sınırlıdır, uygulanacak muafiyet 7 (yedi) gündür.
KLOZ 3C- DEPREM VE YANARDAĞ PÜSKÜRMESİ TEMİNATI MÜŞTEREK SİGORTA VE MUAFİYET KLOZU
Deprem ve yanardağ püskürmesi sigortası, sigorta bedelinin en az % 20'sinin sigortalı üzerinde kalması ve meydana gelecek hasarlarda sigortalının bu oranla hasara iştirak etmesi kaydıyla sigortalıyla müşterek sigorta şeklinde yapılmıştır. Sigortalı ve sigortacı bu oranın artırılması
hususunda anlaşabilirler. Bu durumda prim, sigorta bedeli üzerinden tarifede belirtilen fiyat indirimi
esas alınarak hesaplanır. Bu husus poliçenin ön yüzüne yazılır. Sigortalı, sigorta bedelinden kendi üzerinde tutmayı kabul ve taahhüt ettiği kısmı tekrar sigorta
ettiremez. Sigortalı, meydana gelecek hasarlarda, önceden mutabık kalınan ve poliçede yazılan oranla hasara iştirak eder.
Deprem ve yanardağ püskürmesi teminatı ile ilgili her bir hasarda, sigorta bedeli üzerinden en az %2 oranda bulunacak bir tenzili muafiyet uygulanır. Sigortacı, hasarın bu muafiyet miktarını aşan
kısımdan sorumludur. Sigortalı ve sigortacı, muafiyet oranının arttırılması konusunda anlaşabilirler. Bu durumda fiyattan tarifede belirtilen oranda indirim yapılır. Bu husus poliçenin ön yüzüne yazılır.
Muafiyet uygulaması açısından , her bir 72 saatlik dönem bir hasar sayılır.
Bu poliçe enflasyon korumalı olup, sigorta süresi içinde sigorta konusu varlıkların(kasa muhteviyatı hariç) poliçe üzerinde belirtilen oran kadar ki değer artışlarını da temin eder. Ancak bir hasar anında, değer artışları taşınır ve taşınmaz varlıklar için ayrı ayrı hesaplanır ve artışlar hiç bir şekilde poliçe üzerinde belirtilen enflasyon oranını geçemez. Bu özel kloz tahtında her ay için meydana gelecek değer artışları, poliçe üzerinde belirtilen yıllık enflasyon oranının aylık ortalamasını aşamaz. Diğer yandan, enflasyon özel klozu çerçevesinde hesaplanacak aylık enflasyon koruma oranı hiçbir durumda DİE tarafından belirlenen ve sigorta dönemine denk düşen gerçekleşmiş aylık enflasyon oranını aşamaz. Bu özel kloz yangın sigortası genel klozlarının A-5 maddesinin 1.paragrafı, hırsızlık genel klozlarının A-6 maddesi ve cam kırılması genel klozlarının 12.maddesinde yer alan eksik sigorta hükmünün kaldırıldığı şeklinde yorumlanamaz.
Bu sigorta sözleşmesinde sigortalı , sigorta ettiren, rehinli alacaklı veya sair surette hak sahibinin, Birleşmiş Milletler, Avrupa Birliği ve Amerika Birleşik Devletleri tarafından ticari ve ekonomik yaptırım, yasak veya kısıtlama kararlarına aykırılık teşkil edebilecek teminat, ödeme, hizmet, menfaat veya sair bir iş ilişkisi içinde bulunması halinde herhangi bir şekilde hak sahibi olmaları mümkün değildir. Sigorta konusu menfaat sonradan kendilerine ait olmaya başlamış veya herhangi bir şekilde sigortadan doğan haklar kendilerine hangi şekilde olursa olsun devredilmiş veya intikal etmiş bulunduğu takdirde dahi, sigorta şirketi her türlü teminat sağlama ve ödeme yükümlülüğünden kurtulmuş olur ve hiçbir şekilde sorumlu tutulamaz. İş bu klozda ilgili otoritelerin onayı doğrultusunda belirli olmayan sürelerde değişiklik olması halinde sigortacının poliçe şartlarında değişiklik yapma hakkı saklı kalacaktır.
Teminat verilen riziko adresindeki bina/binalar içerisinde bulunan sigortalıya ait olmayıp işletmede gerek tamirat ya da kullanılmak, gerekse de emaneten muhafaza edilmek gibi her ne sebeple olursa olsun bulunan/bulundurulan her türlü kıymet (emtea, makina, demirbaş gibi) işbu poliçe kapsamına dahildir.
İSTİSNA KIYMETLER: Sigortalıya icra dairesi tarafından yeddi emin sıfatıyla tevdi edilen üçüncü şahıs malları teminata dahil değildir.
Sigortalının leasing (kiralama) kanalı ile satın aldığı her türlü bina, muhteviyat, dekorasyon, makine, ekipman, tesisat, demirbaş vs. sabit kıymetler ancak poliçede belirtilmesi koşuluyla teminata dahildir.
NOT: Poliçede alınmış olması kaydı ile deprem, glkhhknh-t ve sel/su muafiyet kloz hükümlerinde üçüncü şahıs malı, hangi muhteviyat grubuna dahil ise o gruptaki muafiyet uygulanacaktır.
3. şahıs malı poliçede detaylandırılmaması halinde ticari defter kayıtlarına göre deprem, glkhhknh-t ve sel/su muafiyet kloz hükümlerinde belirtilen ve diğer teminatlar için de varsa poliçede belirtilen muafiyetler uygulanacaktır.";
        }

    }


}
