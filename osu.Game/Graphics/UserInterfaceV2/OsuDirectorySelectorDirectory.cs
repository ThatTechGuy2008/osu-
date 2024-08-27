// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics.Sprites;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Graphics.UserInterfaceV2
{
    internal partial class OsuDirectorySelectorDirectory : DirectorySelectorDirectory
    {
        public OsuDirectorySelectorDirectory(DirectoryInfo directory, string displayName = null)
            : base(directory, displayName)
        {
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Flow.AutoSizeAxes = Axes.X;
            Flow.Height = OsuDirectorySelector.ITEM_HEIGHT;

            AddRangeInternal(new Drawable[]
            {
                new HoverClickSounds()
            });

            Colour = colours.Orange1;
        }

        protected override SpriteText CreateSpriteText() => new OsuSpriteText().With(t => t.Font = OsuFont.Default.With(weight: FontWeight.Bold));

        protected override IconUsage? Icon => Directory.Name.Contains(Path.DirectorySeparatorChar)
            ? FontAwesome.Solid.Database
            : FontAwesome.Regular.Folder;
    }
}
