using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dashboard.Models
{
	[XmlRoot(ElementName = "header")]
	public class Header
	{
		[XmlElement(ElementName = "resultCode")]
		public string ResultCode { get; set; }
		[XmlElement(ElementName = "resultMsg")]
		public string ResultMsg { get; set; }
	}

	[XmlRoot(ElementName = "notice")]
	public class Notice
	{
		[XmlElement(ElementName = "rows")]
		public string Rows { get; set; }
	}

	[XmlRoot(ElementName = "item")]
	public class Item
	{
		[Display(Name = "부위명")]
		[XmlElement(ElementName = "cutmeatName")]
		public string CutmeatName { get; set; }

        [Display(Name = "한우(소계) 박스수")]
        [XmlElement(ElementName = "hanBoxCnt")]
        public int HanBoxCnt { get; set; }

        [Display(Name = "한우(1++등급) 박스수")]
        [XmlElement(ElementName = "han_0Cnt")]
        public int Han_0Cnt { get; set; }

        [Display(Name = "한우(1+등급) 박스수")]
        [XmlElement(ElementName = "han_1Cnt")]
        public int Han_1Cnt { get; set; }

        [Display(Name = "한우(1등급) 박스수")]
        [XmlElement(ElementName = "han_2Cnt")]
        public int Han_2Cnt { get; set; }

        [Display(Name = "한우(2등급) 박스수")]
        [XmlElement(ElementName = "han_3Cnt")]
        public int Han_3Cnt { get; set; }

        [Display(Name = "한우(3등급) 박스수")]
        [XmlElement(ElementName = "han_4Cnt")]
        public int Han_4Cnt { get; set; }

        [Display(Name = "한우(등외등급) 박스수")]
        [XmlElement(ElementName = "han_5Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Han_5Cnt { get; set; }

        [Display(Name = "육우(소계)경락가격")]
        [XmlElement(ElementName = "yukAvgT")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int YukAvgT { get; set; }

        [Display(Name = "육우(2등급)경락가격")]
        [XmlElement(ElementName = "yukAvg_3")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int YukAvg_3 { get; set; }

        [Display(Name = "육우(3등급)경락가격")]
        [XmlElement(ElementName = "yukAvg_4")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int YukAvg_4 { get; set; }

        [Display(Name = "육우(소계) 박스수")]
        [XmlElement(ElementName = "yukBoxCnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int YukBoxCnt { get; set; }

        [Display(Name = "육우(1++등급) 박스수")]
        [XmlElement(ElementName = "yuk_0Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_0Cnt { get; set; }

        [Display(Name = "육우(1+등급) 박스수")]
        [XmlElement(ElementName = "yuk_1Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_1Cnt { get; set; }

        [Display(Name = "육우(1등급) 박스수")]
        [XmlElement(ElementName = "yuk_2Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_2Cnt { get; set; }

        [Display(Name = "육우(2등급) 박스수")]
        [XmlElement(ElementName = "yuk_3Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_3Cnt { get; set; }

        [Display(Name = "육우(3등급) 박스수")]
        [XmlElement(ElementName = "yuk_4Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_4Cnt { get; set; }

        [Display(Name = "육우(등외등급) 박스수")]
        [XmlElement(ElementName = "yuk_5Cnt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int Yuk_5Cnt { get; set; }

        [Display(Name = "한우(소계)경락가격")]
        [XmlElement(ElementName = "hanAvgT")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,##}")]
        public int HanAvgT { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "한우(2등급)경락가격")]
		[XmlElement(ElementName = "hanAvg_3")]
		[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C}")]
		public int HanAvg_3 { get; set; }
	}

	[XmlRoot(ElementName = "items")]
	public class Items
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName = "body")]
	public class Body
	{
		[XmlElement(ElementName = "items")]
		public Items Items { get; set; }
	}

	[XmlRoot(ElementName = "response")]
	public class Response
	{
		[XmlElement(ElementName = "header")]
		public Header Header { get; set; }
		[XmlElement(ElementName = "notice")]
		public Notice Notice { get; set; }
		[XmlElement(ElementName = "body")]
		public Body Body { get; set; }

		public static Response ToModel(string body)
        {
			using (System.IO.Stream wr = GenerateStreamFromString(body))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Response));
				var _Object = (Response)xs.Deserialize(wr);

				return _Object;
			}
		}

		internal static System.IO.Stream GenerateStreamFromString(string s)
		{
			var stream = new System.IO.MemoryStream();
			var writer = new System.IO.StreamWriter(stream);
			writer.Write(s);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}
	}
}
