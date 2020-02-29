using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Web;

namespace Foundation.Hackathon.Helpers.Helpers
{
    public static class ItemHelper
    {
        public static Item GetStartItem()
        {
            return GetItemByPath(GetStartItemPath());
        }

        public static string GetStartItemPath()
        {
            return Sitecore.Context.Site.StartPath;
        }

        public static SiteInfo GetItemSite(Item itemYouNeedToCheck)
        {
            return Sitecore.Configuration.Factory.GetSiteInfoList()
                .FirstOrDefault(x => itemYouNeedToCheck.Paths.FullPath.StartsWith(x.RootPath));
        }

        public static Item GetItemByPath(string path, Database database)
        {
            return database.GetItem(path);
        }

        public static Item GetItemByPath(string path)
        {
            return GetItemByPath(path, Context.Database);
        }

        public static Item GetItemByGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return (Item)null;
            else
                return GetItemByGuid(guid, Context.Database);
        }

        public static Item GetItemByGuid(string guid, Database database)
        {
            Guid newGuid;
            if (Guid.TryParse(guid, out newGuid))
                return database.GetItem(guid);
            else
                return (Item)null;

        }

        public static string GetFieldRawValue(Item item, string fieldName)
        {
            String fieldValue = string.Empty;
            if (item != null && item.Fields[fieldName] != null)
                fieldValue = item.Fields[fieldName].Value;
            return fieldValue;
        }

        public static bool GetCheckBoxValueByFieldName(Item item, string fieldName)
        {
            bool flag = false;
            if (item != null)
            {
                try
                {
                    flag = item.Fields[fieldName].Value == "1";
                }
                catch (Exception ex)
                {
                }
            }
            return flag;
        }

        public static List<Item> GetChildItems(Item contextItem)
        {
            List<Item> list = new List<Item>();
            if (contextItem != null)
                list = ((IEnumerable<Item>)contextItem.GetChildren()).ToList();
            return list;
        }

        public static List<Item> GetChildItems(Item contextItem, string templateId)
        {
            List<Item> list = new List<Item>();
            if (contextItem != null)
                list =
                    ((IEnumerable<Item>)contextItem.Children).Where(
                        (Func<Item, bool>)
                            (x => x.TemplateID.ToString().Equals(templateId, StringComparison.OrdinalIgnoreCase)))
                        .ToList();
            return list;
        }

        public static string GetItemUrl(Item item)
        {
            return item == null ? string.Empty : LinkManager.GetItemUrl(item);
        }

        public static string GetItemUrl(Item item, UrlOptions options)
        {
            if (item == null)
                return string.Empty;
            return LinkManager.GetItemUrl(item, options);
        }

        public static string GetImageUrl(Item currentItem, int maxWidth = 0, int width = 0, int maxHeight = 0)
        {
            if (currentItem == null)
                return null;

            var image = (MediaItem)currentItem;

            // If there's options specified, add them to the options object.
            if (width > 0 || maxWidth > 0 || maxHeight > 0)
            {
                var options = new MediaUrlOptions();
                if (width > 0)
                    options.Width = width;
                if (maxWidth > 0)
                    options.MaxWidth = maxWidth;
                if (maxHeight > 0)
                    options.MaxHeight = maxHeight;

                return StringUtil.EnsurePrefix('/',
                    HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(image, options)));
            }

            // Otherwise, get the image with no options specified.
            return StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
        }

        public static string GetGeneralFullLinkUrl(LinkField linkField)
        {
            string url = string.Empty;
            if (linkField == null)
                return string.Empty;
            var options = LinkManager.GetDefaultUrlOptions();
            options.AlwaysIncludeServerUrl = true;

            url = linkField.TargetItem != null ? LinkManager.GetItemUrl(linkField.TargetItem, options) : string.Empty;
            return url;
        }

        public static string GetGeneralLinkUrl(LinkField linkField)
        {
            string url = string.Empty;
            if (linkField == null)
                return string.Empty;

            switch (linkField.LinkType)
            {
                case "internal":
                    url = linkField.TargetItem != null ? GetItemUrl(linkField.TargetItem) : String.Empty;
                    return url;
                case "external":
                case "mailto":
                case "anchor":
                case "javascript":
                    url = linkField.Url;
                    return url;
                case "media":
                    url = linkField.TargetItem != null
                        ? GetMediaUrl((Item)new MediaItem(linkField.TargetItem))
                        : String.Empty;
                    return url;
                default:
                    return String.Empty;
            }
        }

        public static string GetGeneralLinkUrl(Item item, string fieldname = "Link")
        {
            if (item == null)
                return null;

            LinkField field = item.Fields[fieldname];
            if (field == null)
                return null;

            return GetGeneralLinkUrl(field);
        }

        public static string GetGeneralLinkTarget(Item item, string fieldname = "Link")
        {
            if (item == null || string.IsNullOrWhiteSpace(fieldname))
                return null;

            LinkField field = item.Fields[fieldname];
            if (field == null)
                return null;

            return GetGeneralLinkTarget(field);
        }

        public static string GetGeneralLinkText(Item item, string fieldname = "Link")
        {
            if (item == null || string.IsNullOrWhiteSpace(fieldname))
                return null;

            LinkField field = item.Fields[fieldname];
            if (field == null)
                return null;

            return GetGeneralLinkText(field);
        }

        public static string GetGeneralLinkText(LinkField linkField)
        {
            string text = string.Empty;
            if (linkField != null && !string.IsNullOrEmpty(linkField.Text))
            {
                text = linkField.Text;
            }

            return text;
        }

        public static string GetGeneralLinkTarget(LinkField linkField)
        {
            string target = string.Empty;
            if (linkField != null && linkField.Target != null && linkField.Target != "Active Browser")
            {
                target = linkField.Target;
            }

            return target;
        }

        public static string GetDateFieldFormat(Item item, string fieldName = "Date", string format = "G")
        {
            if (item == null || fieldName == null)
                return null;

            DateField field = item.Fields[fieldName];
            if (field == null)
                return null;

            return field.DateTime.ToString(format);
        }

       public static string GetMediaUrl(Item mediaItem)
        {
            string url = mediaItem != null
                ? StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl((MediaItem)mediaItem))
                : String.Empty;
            return url;
        }

        public static string GetCssClassForLink(Item item, string linkFieldName)
        {
            if (item == null || string.IsNullOrEmpty(linkFieldName))
                return string.Empty;

            LinkField linkField = item.Fields[linkFieldName];

            if (linkField == null)
                return string.Empty;

            if (linkField.LinkType.Equals("mailto", StringComparison.InvariantCultureIgnoreCase) || linkField.LinkType.Equals("anchor", StringComparison.InvariantCultureIgnoreCase))
            {
                return linkField.GetAttribute("style");
            }

            return linkField.Class;
        }

        public static List<Item> GetReferrersAsItems(Item item, bool includeStandardValues = false)
        {
            var links = Globals.LinkDatabase.GetReferrers(item);
            if (links == null)
                return new List<Item>();
            var linkedItems = links.Select(i => i.GetSourceItem()).Where(i => i != null);
            if (!includeStandardValues)
                linkedItems =
                    linkedItems.Where(
                        i => !i.Name.Equals("__standard values", StringComparison.InvariantCultureIgnoreCase));
            return linkedItems.ToList();
        }

        public static IEnumerable<Item> GetMultiListParameterItems(string itemIds)
        {
            if (string.IsNullOrEmpty(itemIds))
                return null;

            var splitItemList = itemIds.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            var itemList = splitItemList.Select(itemId =>
            {
                Item item = null;
                Guid id = Guid.Empty;
                if (Guid.TryParse(itemId, out id))
                {
                    item = Context.Database.GetItem(new ID(id));
                }
                return item;
            });

            return itemList.Where(f => f != null);
        }

        public static List<Item> GetMultiListParameterItemsList(string itemIds)
        {
            var enumeration = GetMultiListParameterItems(itemIds);
            return enumeration?.ToList();
        }

        public static List<ID> GetMultiListParameterIds(string itemIds)
        {
            if (string.IsNullOrWhiteSpace(itemIds))
                return new List<ID>();

            var splitItemList = itemIds.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var itemList = splitItemList.Select(itemId =>
            {
                ID id;
                if (ID.TryParse(itemId, out id))
                {
                    return id;
                }
                return default(ID);
            });
            return itemList.Where(f => f != default(ID)).ToList();
        }

        public static List<Guid> GetMultiListParameterGuids(string itemIds)
        {
            if (string.IsNullOrWhiteSpace(itemIds))
                return new List<Guid>();

            var splitItemList = itemIds.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var itemList = splitItemList.Select(itemId =>
            {
                Guid id;
                if (Guid.TryParse(itemId, out id))
                {
                    return id;
                }
                return default(Guid);
            });
            return itemList.Where(f => f != default(Guid)).ToList();
        }

    }
    
}