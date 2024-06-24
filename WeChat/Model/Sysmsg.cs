using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeChatFerry.Model
{
    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [XmlRoot("sysmsg")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SysMsg
    {

        private sysmsgRevokemsg revokemsgField;

        private string typeField;

        /// <remarks/>
        public sysmsgRevokemsg revokemsg
        {
            get
            {
                return this.revokemsgField;
            }
            set
            {
                this.revokemsgField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class sysmsgRevokemsg
    {

        private string sessionField;

        private uint msgidField;

        private ulong newmsgidField;

        private string replacemsgField;

        private string announcement_idField;

        /// <remarks/>
        public string session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }

        /// <remarks/>
        public uint msgid
        {
            get
            {
                return this.msgidField;
            }
            set
            {
                this.msgidField = value;
            }
        }

        /// <remarks/>
        public ulong newmsgid
        {
            get
            {
                return this.newmsgidField;
            }
            set
            {
                this.newmsgidField = value;
            }
        }

        /// <remarks/>
        public string replacemsg
        {
            get
            {
                return this.replacemsgField;
            }
            set
            {
                this.replacemsgField = value;
            }
        }

        /// <remarks/>
        public string announcement_id
        {
            get
            {
                return this.announcement_idField;
            }
            set
            {
                this.announcement_idField = value;
            }
        }
    }


}
