﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Threading;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Notifo.Domain.Channels.MobilePush;
using Notifo.Domain.UserNotifications;

namespace Notifo.Domain.Integrations.Firebase
{
    public sealed class FirebaseMobilePushSender : IMobilePushSender, IDisposable
    {
        private readonly FirebaseApp app;
        private readonly FirebaseMessaging messaging;

        public FirebaseMobilePushSender(string projectId, string credentials)
        {
            var appOptions = new AppOptions
            {
                Credential = GoogleCredential.FromJson(credentials)
            };

            appOptions.ProjectId = projectId;

            app = FirebaseApp.Create(appOptions);

            messaging = FirebaseMessaging.GetMessaging(app);
        }

        public void Dispose()
        {
            app.Delete();
        }

        public Task SendAsync(UserNotification userNotification, string token, bool wakeup, CancellationToken ct)
        {
            var message = userNotification.ToFirebaseMessage(token, wakeup);

            return messaging.SendAsync(message, ct);
        }
    }
}