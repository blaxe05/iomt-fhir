﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Newtonsoft.Json.Linq;

namespace Microsoft.Health.Fhir.Ingest.Template
{
    public class JsonPathContentTemplateFactory : HandlerProxyTemplateFactory<TemplateContainer, IContentTemplate>
    {
        public override IContentTemplate Create(TemplateContainer jsonTemplate)
        {
            const string targetTypeName = "JsonPathContentTemplate";
            if (!jsonTemplate.MatchTemplateName(targetTypeName))
            {
                return null;
            }

            if (jsonTemplate.Template?.Type != JTokenType.Object)
            {
                throw new InvalidTemplateException($"Expected an object for the template property value for template type {targetTypeName}.");
            }

            return jsonTemplate.Template.ToObject<JsonPathContentTemplate>();
        }
    }
}