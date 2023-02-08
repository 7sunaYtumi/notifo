﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

namespace Notifo.Domain.Integrations;

public sealed record IntegrationDefinition(
    string Type,
    string Title,
    string Logo,
    IReadOnlyList<IntegrationProperty> Properties,
    IReadOnlyList<IntegrationProperty> UserProperties,
    IReadOnlySet<string> Capabilities)
{
    public string? Description { get; init; }
}
