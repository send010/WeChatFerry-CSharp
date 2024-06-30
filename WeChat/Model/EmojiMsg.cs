using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsApp1
{
    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [XmlRoot("msg")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EmojiMsg
    {

        private msgEmoji emojiField;

        /// <remarks/>
        public msgEmoji emoji
        {
            get
            {
                return this.emojiField;
            }
            set
            {
                this.emojiField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class msgEmoji
    {

        private string fromusernameField;

        private string tousernameField;

        private byte typeField;

        private string idbufferField;

        private string md5Field;

        private uint lenField;

        private string productidField;

        private string androidmd5Field;

        private uint androidlenField;

        private string s60v3md5Field;

        private uint s60v3lenField;

        private string s60v5md5Field;

        private uint s60v5lenField;

        private string cdnurlField;

        private string designeridField;

        private string thumburlField;

        private string encrypturlField;

        private string aeskeyField;

        private string externurlField;

        private string externmd5Field;

        private ushort widthField;

        private byte heightField;

        private string tpurlField;

        private string tpauthkeyField;

        private string attachedtextField;

        private string attachedtextcolorField;

        private string lensidField;

        private string emojiattrField;

        private string linkidField;

        private string descField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fromusername
        {
            get
            {
                return this.fromusernameField;
            }
            set
            {
                this.fromusernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tousername
        {
            get
            {
                return this.tousernameField;
            }
            set
            {
                this.tousernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string idbuffer
        {
            get
            {
                return this.idbufferField;
            }
            set
            {
                this.idbufferField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string md5
        {
            get
            {
                return this.md5Field;
            }
            set
            {
                this.md5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint len
        {
            get
            {
                return this.lenField;
            }
            set
            {
                this.lenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string productid
        {
            get
            {
                return this.productidField;
            }
            set
            {
                this.productidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string androidmd5
        {
            get
            {
                return this.androidmd5Field;
            }
            set
            {
                this.androidmd5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint androidlen
        {
            get
            {
                return this.androidlenField;
            }
            set
            {
                this.androidlenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string s60v3md5
        {
            get
            {
                return this.s60v3md5Field;
            }
            set
            {
                this.s60v3md5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint s60v3len
        {
            get
            {
                return this.s60v3lenField;
            }
            set
            {
                this.s60v3lenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string s60v5md5
        {
            get
            {
                return this.s60v5md5Field;
            }
            set
            {
                this.s60v5md5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint s60v5len
        {
            get
            {
                return this.s60v5lenField;
            }
            set
            {
                this.s60v5lenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cdnurl
        {
            get
            {
                return this.cdnurlField;
            }
            set
            {
                this.cdnurlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string designerid
        {
            get
            {
                return this.designeridField;
            }
            set
            {
                this.designeridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumburl
        {
            get
            {
                return this.thumburlField;
            }
            set
            {
                this.thumburlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string encrypturl
        {
            get
            {
                return this.encrypturlField;
            }
            set
            {
                this.encrypturlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string aeskey
        {
            get
            {
                return this.aeskeyField;
            }
            set
            {
                this.aeskeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string externurl
        {
            get
            {
                return this.externurlField;
            }
            set
            {
                this.externurlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string externmd5
        {
            get
            {
                return this.externmd5Field;
            }
            set
            {
                this.externmd5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tpurl
        {
            get
            {
                return this.tpurlField;
            }
            set
            {
                this.tpurlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tpauthkey
        {
            get
            {
                return this.tpauthkeyField;
            }
            set
            {
                this.tpauthkeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string attachedtext
        {
            get
            {
                return this.attachedtextField;
            }
            set
            {
                this.attachedtextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string attachedtextcolor
        {
            get
            {
                return this.attachedtextcolorField;
            }
            set
            {
                this.attachedtextcolorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lensid
        {
            get
            {
                return this.lensidField;
            }
            set
            {
                this.lensidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string emojiattr
        {
            get
            {
                return this.emojiattrField;
            }
            set
            {
                this.emojiattrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string linkid
        {
            get
            {
                return this.linkidField;
            }
            set
            {
                this.linkidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }
    }


}
