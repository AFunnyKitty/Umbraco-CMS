﻿using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace Umbraco.Core.Components
{
    //TODO: This should just exist in the content service/repo!
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public sealed class RelateOnCopyComponent : UmbracoComponentBase, IUmbracoCoreComponent
    {
        public void Initialize()
        {
            ContentService.Copied += ContentServiceCopied;
        }

        private static void ContentServiceCopied(IContentService sender, Events.CopyEventArgs<NotificationData> e)
        {
            if (e.RelateToOriginal == false) return;

            var relationService = Current.Services.RelationService;

            var relationType = relationService.GetRelationTypeByAlias(Constants.Conventions.RelationTypes.RelateDocumentOnCopyAlias);

            if (relationType == null)
            {
                relationType = new RelationType(Constants.ObjectTypes.Document,
                    Constants.ObjectTypes.Document,
                    Constants.Conventions.RelationTypes.RelateDocumentOnCopyAlias,
                    Constants.Conventions.RelationTypes.RelateDocumentOnCopyName) { IsBidirectional = true };

                relationService.Save(relationType);
            }

            var relation = new Relation(e.Original.Content.Id, e.Copy.Content.Id, relationType);
            relationService.Save(relation);

            Current.Services.AuditService.Add(
                AuditType.Copy,
                e.Copy.Content.WriterId,
                e.Copy.Content.Id, ObjectTypes.GetName(UmbracoObjectTypes.Document),
                $"Copied content with Id: '{e.Copy.Content.Id}' related to original content with Id: '{e.Original.Content.Id}'");
        }
    }
}
