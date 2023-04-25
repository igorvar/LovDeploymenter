using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovDeployment
{
    internal sealed class DataGridViewSetting : ApplicationSettingsBase
    {
        private static DataGridViewSetting _defaultInstace =
        (DataGridViewSetting)ApplicationSettingsBase.Synchronized(new DataGridViewSetting());
        public static DataGridViewSetting Default
        {
            get { return _defaultInstace; }
        }
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DefaultSettingValue("")]
        public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
        {
            get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
            set { this["ColumnOrder"] = value; }
        }
    }
    [Serializable]
    public sealed class ColumnOrderItem
    {
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int ColumnIndex { get; set; }
    }
}
