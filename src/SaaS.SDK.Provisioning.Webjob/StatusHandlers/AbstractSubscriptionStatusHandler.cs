﻿namespace Microsoft.Marketplace.SaasKit.Provisioning.Webjob.StatusHandlers
{
    using Microsoft.Marketplace.SaasKit.Client.DataAccess.Contracts;
    using Microsoft.Marketplace.SaasKit.Client.DataAccess.Entities;
    using System;

    /// <summary>
    /// Base class for all the subscription status handlers. Provides common methods to access plan / subscription and user details.
    /// </summary>
    /// <seealso cref="Microsoft.Marketplace.SaasKit.Provisioning.Webjob.StatusHandlers.ISubscriptionStatusHandler" />
    public abstract class AbstractSubscriptionStatusHandler : ISubscriptionStatusHandler
    {
        /// <summary>
        /// The subscriptions repository
        /// </summary>
        protected readonly ISubscriptionsRepository subscriptionsRepository;

        /// <summary>
        /// The plans repository
        /// </summary>
        protected readonly IPlansRepository plansRepository;

        /// <summary>
        /// The users repository
        /// </summary>
        protected readonly IUsersRepository usersRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSubscriptionStatusHandler"/> class.
        /// </summary>
        /// <param name="subscriptionsRepository">The subscriptions repository.</param>
        /// <param name="plansRepository">The plans repository.</param>
        /// <param name="usersRepository">The users repository.</param>
        public AbstractSubscriptionStatusHandler(   
                                                    ISubscriptionsRepository subscriptionsRepository, 
                                                    IPlansRepository plansRepository,
                                                    IUsersRepository usersRepository
                                                )
        {
            this.subscriptionsRepository = subscriptionsRepository;
            this.plansRepository = plansRepository;
            this.usersRepository = usersRepository;
        }

        /// <summary>
        /// Gets the subscription by identifier.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <returns></returns>
        protected Subscriptions GetSubscriptionById(Guid subscriptionId)
        {
            return subscriptionsRepository.GetById(subscriptionId);            
        }

        /// <summary>
        /// Gets the plan by identifier.
        /// </summary>
        /// <param name="planId">The plan identifier.</param>
        /// <returns></returns>
        protected Plans GetPlanById(string planId)
        {
            return plansRepository.GetById(planId);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        protected Users GetUserById(int? userId)
        {
            return usersRepository.Get(userId.GetValueOrDefault());
        }

        /// <summary>
        /// Processes the specified subscription identifier.
        /// </summary>
        /// <param name="subscriptionID">The subscription identifier.</param>
        public abstract void Process(Guid subscriptionID);
    }
}
