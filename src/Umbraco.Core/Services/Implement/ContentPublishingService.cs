using System;
using System.Linq;
using Umbraco.Core.Exceptions;
using Umbraco.Core.Models;

namespace Umbraco.Core.Services.Implement
{
    public class ContentPublishingService : IContentPublishingService
    {
//        private readonly IContentTypeService _contentTypeService;
//
//        public ContentPublishingService(IContentTypeService contentTypeService)
//        {
//            _contentTypeService = contentTypeService;
//        }
//
//        /// <inheritdoc />
//        public virtual bool PublishCulture(IContent content, string culture = "*")
//        {
//            culture = culture.NullOrWhiteSpaceAsNull();
//
//            ThrowIfCultureNotSupportedByContentType(content, culture);
//
//            // the values we want to publish should be valid
//            if (content.ValidateProperties(culture).Any())
//                return false;
//
//            var alsoInvariant = false;
//            if (culture == "*") // all cultures
//            {
//                foreach (var c in content.AvailableCultures)
//                {
//                    var name = content.GetCultureName(c);
//                    if (string.IsNullOrWhiteSpace(name))
//                        return false;
//                    content.SetPublishInfo(c, name, DateTime.Now);
//                }
//            }
//            else if (culture == null) // invariant culture
//            {
//                if (string.IsNullOrWhiteSpace(content.Name))
//                    return false;
//                // PublishName set by repository - nothing to do here
//            }
//            else // one single culture
//            {
//                var name = content.GetCultureName(culture);
//                if (string.IsNullOrWhiteSpace(name))
//                    return false;
//                content.SetPublishInfo(culture, name, DateTime.Now);
//                alsoInvariant = true; // we also want to publish invariant values
//            }
//
//            // property.PublishValues only publishes what is valid, variation-wise
//            foreach (var property in content.Properties)
//            {
//                property.PublishValues(culture);
//                if (alsoInvariant)
//                    property.PublishValues(null);
//            }
//
//            content.PublishedState = PublishedState.Publishing;
//            return true;
//        }
//
//        /// <inheritdoc />
//        public virtual void UnpublishCulture(IContent content, string culture = "*")
//        {
//            culture = culture.NullOrWhiteSpaceAsNull();
//
//            ThrowIfCultureNotSupportedByContentType(content, culture);
//
//            if (culture == "*") // all cultures
//                ClearPublishInfos(content);
//            else // one single culture
//                ClearPublishInfo(culture);
//
//            // property.PublishValues only publishes what is valid, variation-wise
//            foreach (var property in content.Properties)
//                property.UnpublishValues(culture);
//
//            content.PublishedState = PublishedState.Publishing;
//        }
//
//
//        private void ThrowIfCultureNotSupportedByContentType(IContent content, string culture)
//        {
//            var contentType = _contentTypeService.Get(content.ContentTypeId);
//            // the variation should be supported by the content type properties
//            //  if the content type is invariant, only '*' and 'null' is ok
//            //  if the content type varies, everything is ok because some properties may be invariant
//            if (!contentType.SupportsPropertyVariation(culture, "*", true))
//                throw new NotSupportedException(
//                    $"Culture \"{culture}\" is not supported by content type \"{contentType.Alias}\" with variation \"{contentType.Variations}\".");
//        }
//
//        private void ClearPublishInfos(IContent content)
//        {
//            content._publishInfos = null;
//        }
//
//        private void ClearPublishInfo(string culture)
//        {
//            if (culture.IsNullOrWhiteSpace())
//                throw new ArgumentNullOrEmptyException(nameof(culture));
//
//            if (_publishInfos == null) return;
//            _publishInfos.Remove(culture);
//            if (_publishInfos.Count == 0) _publishInfos = null;
//        }
//


        public bool PublishCulture(IContent content, string culture = "*")
        {
            throw new NotImplementedException();
        }

        public void UnpublishCulture(IContent content, string culture = "*")
        {
            throw new NotImplementedException();
        }
    }
}
