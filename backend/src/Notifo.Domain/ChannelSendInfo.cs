﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using NodaTime;
using Notifo.Domain.Channels;
using Notifo.Domain.Integrations;

namespace Notifo.Domain;

public sealed class ChannelSendInfo
{
    public SendConfiguration Configuration { get; set; }

    public DeliveryStatus Status { get; set; }

    public Instant LastUpdate { get; set; }

    public Instant? FirstConfirmed { get; set; }

    public Instant? FirstSeen { get; set; }

    public Instant? FirstDelivered { get; set; }

    public string? Detail { get; set; }
}
