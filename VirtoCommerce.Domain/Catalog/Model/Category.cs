using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class Category : AuditableEntity, ILinkSupport, ISeoSupport, IHasOutlines, IHasImages, IHasProperties
    {
        public Category()
        {
            IsActive = true;
        }
        public string CatalogId { get; set; }
        public Catalog Catalog { get; set; }

        public string ParentId { get; set; }
        public string Code { get; set; }
        public string TaxType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsVirtual { get; set; }
        public int Level { get; set; }
        public Category[] Parents { get; set; }
        public int PendingApprovalCount { get; set; }
        public int RejectedCount { get; set; }

        //Type of product package (set of package types with their specific dimensions) can be inherited by nested products and categories
        public string PackageType { get; set; }

        public int Priority { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Category> Children { get; set; }

        #region IHasProperties members
        public ICollection<Property> Properties { get; set; }
        public ICollection<PropertyValue> PropertyValues { get; set; }
        #endregion

        #region ILinkSupport members
        public ICollection<CategoryLink> Links { get; set; }
        #endregion

        public string SeoObjectType { get { return GetType().Name; } }
        public ICollection<SeoInfo> SeoInfos { get; set; }

        #region IHasImages members
        public ICollection<Image> Images { get; set; }
        #endregion

        #region IHasOutlines members
        public ICollection<Outline> Outlines { get; set; }
        #endregion

        public virtual void ReduceDetails(string responseGroup)
        {
            //Reduce details according to response group
            var categoryResponseGroup = EnumUtility.SafeParseFlags(responseGroup, CategoryResponseGroup.Full);

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithImages))
            {
                Images = null;
            }

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithLinks))
            {
                Links = null;
            }

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithParents))
            {
                Parents = null;
            }

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithProperties))
            {
                Properties = null;
                PropertyValues = null;
            }

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithOutlines))
            {
                Outlines = null;
            }

            if (!categoryResponseGroup.HasFlag(CategoryResponseGroup.WithSeo))
            {
                SeoInfos = null;
            }
        }
    }
}
