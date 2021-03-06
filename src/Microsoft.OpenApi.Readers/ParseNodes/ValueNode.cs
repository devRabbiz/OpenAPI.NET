﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 

using System;
using System.Globalization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Readers.Exceptions;
using SharpYaml.Serialization;

namespace Microsoft.OpenApi.Readers.ParseNodes
{
    internal class ValueNode : ParseNode
    {
        private readonly YamlScalarNode _node;

        public ValueNode(ParsingContext context, OpenApiDiagnostic diagnostic, YamlNode node) : base(
            context,
            diagnostic)
        {
            if (!(node is YamlScalarNode scalarNode))
            {
                throw new OpenApiReaderException("Expected a value.", node);
            }
            _node = scalarNode;
        }

        public override string GetScalarValue()
        {
            return _node.Value;
        }

        /// <summary>
        /// Create a <see cref="IOpenApiPrimitive"/>
        /// </summary>
        /// <returns>The created Any object.</returns>
        public override IOpenApiAny CreateAny()
        {
            var value = GetScalarValue();
            return new OpenApiString(value);
        }
    }
}
