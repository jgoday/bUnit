using System;
using Bunit.Rendering;

namespace Bunit
{
	/// <inheritdoc/>
	public sealed class ComponentChangeEventSubscriber : ConcurrentRenderEventSubscriber
    {
        private readonly IRenderedFragmentCore _testTarget;

        /// <summary>
        /// Creates an instance of the <see cref="ComponentChangeEventSubscriber"/>.
        /// </summary>
        public ComponentChangeEventSubscriber(IRenderedFragmentCore testTarget, Action<RenderEvent>? onChange = null, Action? onCompleted = null)
            : base((testTarget ?? throw new ArgumentNullException(nameof(testTarget))).RenderEvents, onChange, onCompleted)
        {
            _testTarget = testTarget;
        }

        /// <inheritdoc/>
        public override void OnNext(RenderEvent value)
        {
            if (value.HasChangesTo(_testTarget.ComponentId))
                base.OnNext(value);
        }
    }
}