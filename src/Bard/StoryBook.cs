using System;
using Bard.Internal.Exception;
using Bard.Internal.Given;

namespace Bard
{
    public abstract class StoryBook
    {
        internal ScenarioContext? Context { get; set; }

        /// <summary>
        ///     Define the action of your story.
        /// </summary>
        /// <param name="storyData"></param>
        /// <typeparam name="TStoryData"></typeparam>
        /// <returns></returns>
        /// <exception cref="BardConfigurationException"></exception>
        protected IBeginWhen<TStoryData> When<TStoryData>(Func<ScenarioContext, TStoryData> storyData)
            where TStoryData : class, new()
        {
            if (Context == null)
                throw new BardConfigurationException($"{nameof(Context)} has not been set.");

            var context = new ScenarioContext<TStoryData>(Context);

            return new BeginWhen<TStoryData>(context, storyData);
        }

        /// <summary>
        ///     Define the parameters of your story.
        /// </summary>
        /// <param name="storyParameter"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="BardConfigurationException"></exception>
        protected IBeginGiven<TRequest> Given<TRequest>(Func<TRequest> storyParameter)
        {
            if (Context == null)
                throw new BardConfigurationException($"{nameof(Context)} has not been set.");

            return new BeginGiven<TRequest>(Context, storyParameter);
        }
    }
}