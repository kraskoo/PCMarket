namespace PCMarket.Data.Seeds
{
    using System.Linq;
    using Interfaces;
    using Models.Entities.News;

    public class HardwareNewsSeed : IPcMarketContextSeed
    {
        public void Seed(PcMarketContext context)
        {
            if (!context.HardwareNews.Any())
            {
                context.HardwareNews.Add(new HardwareNew
                {
                    Title = "AMD: VR requires creators to 'rethink the Z'",
                    Subject = "Development Tools, VR",
                    ContentBody = new[]
                    {
                        "VR is coming of age, but it will suffer unless creators ‘rethink the Z’ and don’t let content of the past define content of the future.",
                        "That was the message of AMD Corporate Vice President Roy Taylor in the opening keynote of VR World Congress. “Our understanding of virtual reality is seen through the prism of our current understanding, and our understanding is going to develop,” observes Taylor. Pioneering studies into how time distorts while in VR, and how pain can be decreased using virtual reality, could have a major impact on how content is developed for a wide range of use cases. “We are at the beginning, and we’re going to see some wonderful changes start to happen.”",
                        "BAFTA (British Academy of Film and Television Arts) produced a sizzle reel highlighting the best of VR across various categories; each displaying how far the industry has advanced and the incredible content we’re beginning to see with deeper levels of immersion and engagement than ever before.",
                        "“As great as that content is, one of the challenges we have is we need to ‘rethink the Z’,” says Taylor. “We’ve been looking for 120 years through a window and we’re starting to experiment for the first time we’ve stepped through that window into the other side – but we’re looking at it through the prism of our current knowledge and experience.”",
                        "It’s observed that early movies appeared like plays because we understood theatre, and the first VR now appears like movies because we understand film. Likening it to the ‘X, Y, Z’ axis on a graph, we’re able to go forward in ‘Z depth’ Taylor says, “in ways we’re yet to fully understand.”",
                        "An example is provided of Case Western Reserve University who are using HoloLens to observe the human body. In VR we don’t just have the ability to look at organs, how the blood works, and that kind of thing... but we have the ability to look at how cells work. We can go into subatomic detail forward into the body, or backwards out into the universe. “This scale, to go from subatomic to universal size, and yet we’re only operating in this [X, Y] part here, we’re only using part of the Z,” explains Taylor. “We need to think how far in we can go, and how far out we can go.”",
                        "Technology is advancing at such a rate – driven by demand and fierce competition – that Taylor recommends creators don’t target what computers are able to render today, but what they’ll be able to achieve by the time your project hits the market. He says, it’s easier to scale things down to reach performance targets later than it is to scale them up.",
                        "Getting to photorealism in VR is the next step, while ‘full presence’ is the ultimate goal where it’s indistinguishable between real life and virtual. Achieving that today is out of reach as it would take 1000 TFLOPS of performance.",
                        "Movement has proven a problem so far in virtual reality as most people don’t have the room to run about without causing damage or hurting themselves, or don’t have the money for expensive and bulky equipment like the Virtuix Omni self-contained treadmill. But movement is one of the most important aspects to feel natural for any sense of realism.",
                        "One company Taylor is excited about is Servios and their ‘Fluid Locomotion’ technology which is being demonstrated in their Sprint Vector game. The idea is using natural hand movements, such as running, to propel yourself forward within a virtual environment. “You can leap, you can walk, you can run, you can duck, you can roll, and I can tell you if you’ve not tried it, it’s completely intuitive,” comments Taylor.",
                        "VR is exciting, but it’s going to take a different approach to creating immersive content now we’ve stepped “through the window” if we’re going to make the most of it. As Taylor says, we need to 'rethink the Z'.",
                        "How do you think VR content should be approached? Share your thoughts in the comments."
                    }
                });

                context.HardwareNews.Add(new HardwareNew
                {
                    Title = "Opinion: Windows 10 Cloud offers Microsoft another shot at mobile",
                    Subject = "Cloud, Devices, Platforms, Windows",
                    ContentBody = new[]
                    {
                        "Several references to ‘Windows 10 Cloud’ have appeared in recent Windows test builds and insiders believe it’s Microsoft’s answer to Chrome OS.",
                        "Reports claim Windows 10 Cloud will drop support for Win32/64 and rely on UWP apps similar to Google’s ongoing roll-out of Android support in Chrome OS. There was a time when Chromebooks were only useful for web browsing or putting together a quick document, but the latest devices are changing that conception.",
                        "Some of the latest Chromebooks boast high-end designs and capable hardware which showcases the wide range of Android apps now available on the platform. There are Android apps for just about every task you’d need to accomplish; while also offering apps from major brands that were often absent on Windows.",
                        "Chromebooks are becoming a tempting proposition for average users and Microsoft knows it. Other than a small percentage of individuals who demand peak performance such as 3D designers and gamers, most consumers will be happy to spend less than a Windows laptop on a Chromebook for access to most of the latest apps and generally longer battery life.",
                        "If the reports are correct, Microsoft will attempt to counter this with Windows 10 Cloud, but there’s little denying the company is entering the ring from a weaker position. Google has a vast library of touch-optimised apps at its disposal in the Play Store while Microsoft will find itself back in the position of enticing developers to build UWP apps for their platform.",
                        "The problem Microsoft had in the past is the small market-share of Windows Phone users provided little incentive for developers to waste resources on supporting the platform. If Microsoft can price aggressively enough to flood the market with Windows 10 Cloud devices, then it could attract more developers. If not, Microsoft is heading for another embarrassing failure like Windows RT.",
                        "Do you think ‘Windows 10 Cloud’ is a good idea?"
                    }
                });

                context.HardwareNews.Add(new HardwareNew
                {
                    Title = "Opinion: Nintendo knew it had to Switch it up",
                    Subject = "Devices, Gaming, Platforms",
                    ContentBody = new[]
                    {
                        "Nintendo has previewed its long-awaited codename 'NX' console and sticking to company tradition it takes a refreshing approach to gaming – it now even has a name, the Nintendo Switch.",
                        "While the competition sticks to pushing as powerful consoles as possible, Nintendo is sticking to making gaming fun and versatile. After the PS Vita fizzled out, the 3DS became the sole survivor in the dedicated handheld console space and Nintendo is building on its strength to deliver a hybrid console which can \"Switch\" between a home console, a handheld, and micro console for on the move.",
                        "Switch 1 – The home console",
                        "Not forgetting people enjoy playing games at home on the big screen – and even more so when sharing the experience on the couch – Nintendo is enabling the Switch to be docked for standard gaming on your home TV.",
                        "The company appears to have learned a couple of lessons from its past couple of iterations of their Wii console. Unlike the original Wii, it appears like the Switch will have enough power to push the expected minimum of 1080p content. Unlike the Wii U, instead of a gimmicky \"tablet\" input which felt like the console didn't quite know what it wanted to be, the Switch caters for gamers of all types no matter where they want to play.",
                        "In the promo video we get to see two controller types. The first controller should provide comfort to fans of traditional games with a controller like you would find on your Xbox, PlayStation, or pre-Wii home console from Nintendo itself (granted such a controller was available for the Wii, but it was treated like the accessory it was sold as.)",
                        "The second controller appears like a mini version of the Wiimote and \"nunchuck\" with two motion-sensitive devices for use in either hand. Unlike the Wiimote and nunchuck, these are both wireless and the lack of a strap for your arm seems to suggest the motion actions won't put your TV in as much danger as the original Wii controller.",
                        "Switch 2 – The handheld",
                        "Docking the aforementioned smaller controllers on the sides of the main Switch unit's display when docked will allow you to pick it up and take it on your travels. In use, this functions like the Wii U tablet with a decent-sized display in the middle and controls on either side.",
                        "With the use of cartridges – a touch which is going to bring a dose of nostalgia to players of older consoles – the Switch appears to be able to function without compromise while on-the-move unlike the Wii U's tablet and can be used whether you're at the park, on public transport, or anywhere else it's safe to start gaming.",
                        "Switch 3 – The micro-console",
                        "The most impressive form of the Switch is when it's used as a micro-console. A kickstand on the back of the main unit allows it to be propped up and the controllers detached for a gaming experience on-the-move almost like you're at home. The clip of a man doing just this while on a plane to continue playing Skyrim will have been a highlight for many gamers, and it's sure to shift units.",
                        "With two controllers on the side of the Switch which can be detached, this can lead to some unique gaming experiences with friends while on the go from a device which can be put in your bag. You can either play competitively or work together.",
                        "Conclusion",
                        "We're yet to see final specs, but the initial showing from Nintendo appears impressive and the preview video has sent social media into meltdown (along with Nintendo's servers it would appear.)",
                        "There's a lot more questions which need answers yet, one of which a Nintendo fan highlighted to me earlier about whether a voice chat service will be available. This has become a staple of social experiences on rival platforms for years, and while Nintendo rightly promotes multiplayer gaming together in-person, sometimes you have no choice when your gaming partner is across the world.",
                        "A solid launch line-up and continued support are required, a downfall of the Wii U. This also means Nintendo must attract support from big third-party developers who all but abandoned the last couple of consoles from the house of Mario. This could be the last chance for Nintendo to retake its crown, and I'm quietly hopeful."
                    }
                });

                context.HardwareNews.Add(new HardwareNew
                {
                    Title = "Developers in six new countries are now able to pre-order Microsoft HoloLens",
                    Subject = "Devices, Platforms, VR, Windows",
                    ContentBody = new[]
                    {
                        "Microsoft's impressive AR headset, HoloLens, is now available for pre-order by developers and commercial enterprises in six new countries as it reaches a new milestone towards a full consumer release.",
                        "If you're a resident of Australia, Ireland, France, Germany, New Zealand, or the United Kingdom, you're now able to place your order for a HoloLens unit. In a blog post, Microsoft wrote: \"In welcoming these six new countries, October 12, 2016 marks another major milestone for us.\"",
                        "\"Each of these moments bring us closer to a more personal way of interacting with technology. They empower us to go further together, making it possible for people to communicate, create and collaborate more easily than ever before.\"",
                        "The HoloLens journey so far: ",
                        "January 21, 2015: Microsoft HoloLens introduced, the world’s first and still only, self-contained holographic computer. A vision was shared for what is possible when you bring holograms into our world and we demonstrated how holograms have the potential to revolutionise the way we work, communicate, learn and play.",
                        "March 30, 2016: HoloLens shipped in the United States and Canada and invited developers and organisations to step away from the 2D confines of monitors and pixels to explore what’s possible when technology enters our physical world.",
                        "June 1, 2016: Microsoft announced that mixed reality is coming to PCs. The company invited their virtual reality partners to break down the barriers between virtual and physical reality and combined Windows Holographic with the power of the PC and all its Virtual Reality innovation to enable new mixed reality experiences that are \"simply not possible on any other platform.\"",
                        "News of HoloLens' continued development was quiet for a while, but it's clear Microsoft has been hard at work behind-the-scenes on preparing the device for an increased rollout. Over 80 exclusive mixed reality apps are now available in the Windows Store. Developers are turning floors into lava, creating aquariums in living rooms, setting off mixed reality fireworks, and creating new ways to improve the quality of life for humanity through the power of holograms.",
                        "\"For everyone joining us in our six new countries, welcome! I am looking forward to seeing what you dream and create, as you join the growing set of people and organisations whose passion and ingenuity are changing  the future of computing,\" said Alex Kipman from the OS Group at Microsoft.",
                        "Do you plan on pre-ordering a HoloLens unit?"
                    }
                });
            }
        }
    }
}