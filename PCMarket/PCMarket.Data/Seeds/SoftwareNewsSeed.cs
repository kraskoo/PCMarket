namespace PCMarket.Data.Seeds
{
    using System.Linq;
    using Models.Entities.News;
    using Interfaces;

    public class SoftwareNewsSeed : IPcMarketContextSeed
    {
        public void Seed(PcMarketContext context)
        {
            if (!context.SoftwareNews.Any())
            {
                context.SoftwareNews.Add(new SoftwareNew
                {
                    Title = "VR and AR developers ‘need to show more focus and ambition’ to attract growth",
                    Subject = "Ecosystem, VR",
                    ContentBody = new[]
                    {
                        "A new piece of research issued by the Brabant Development Agency (BOM) argues there is a ‘wide discrepancy’ between the revenue ambitions and reality for developers in virtual and augmented reality.",
                        "The survey, which polled more than 600 developers and users of VR and AR technology in the Netherlands, Belgium and Germany, found that half of developers whose firms would need more financing said they would need another round of more than €1 million. BOM argues that companies would need the ambition to raise at least €10m in revenue within five years, although the average company expects to raise ‘only’ €1.3m.",
                        "This lack of revenue has been put down to various factors, according to the survey, including ‘unfamiliarity with the possibilities’ of VR and AR, as well as an insufficient business case.",
                        "“It’s always hard to predict how a new technology will be applied in your industry, which holds particularly true in this case,” said Coen Sanderink, BOM business developer. “VR/AR involves a virtual world. You need to experience it before you can understand its potential.”",
                        "Despite this somewhat gloomy opening, Sanderink adds there is a strong upside – but that developers and organisations can’t dither for too long, citing the importance of building significant positions in a specific market segment, such as training for offshore oil workers, or active eSports.",
                        "“VR/AR is here to stay and we see strong signs in our research that it will be serious business in five to 10 years,” he added. “A key conclusion is that now is the time for potential users to start experimenting and explore their role in this rapidly evolving space.”",
                        "According to VisionMobile’s most recent State of the Developer Nation report, around a third of developers polled had some level of involvement in AR and VR, but only one in five (21%) considered themselves professionals."
                    }
                });

                context.SoftwareNews.Add(new SoftwareNew
                {
                    Title = "Facebook appears to reject more code from its female engineers",
                    Subject = "Facebook, Industry",
                    ContentBody = new[]
                    {
                        "A former engineer at Facebook used data compiled over five years in a bid to prove there's a gender bias at the social networking giant against its female employees.",
                        "The compiled data shows female engineers’ code being rejected 35 percent more than males during the review process. While this alone rings some alarm bells, the fact that females waited for 3.9 percent longer on average for their code to be reviewed, and received 8.2 percent more comments, just adds evidence to the bias claim.",
                        "Facebook responded with its own investigation and concluded the rejections had nothing to do with employees’ gender, but with rank. This highlights a continued problem in many companies where higher-ranked positions are often given to males.",
                        "Part of this could be due to a smaller talent pool of female engineers. In statistics posted at the end of last year by British university admissions service UCAS, the subject with the biggest gender gap was computer science, with 13,085 more male students than female.",
                        "It’s clear more work is needed to attract females into STEM (Science, Technology, Engineering, and Mathematics) careers, but the fields are so male-dominated they aren’t seen as being accepting. According to research by Catalyst, a leading non-profit organization with a mission to accelerate progress for women through workplace inclusion, hostile male-dominated work environments, ineffective executive feedback, isolation, and a lack of effective sponsors are factors pushing women to leave SET jobs. Almost one-third of women in the United States (32%) and China (30%) intend to leave their SET jobs within a year.",
                        "This proves to be a vicious cycle as the more women who drop out STEM careers prevents reaching a gender balance while dissuading others to pursue careers in the fields. All companies in STEM fields need to work hard to attract more female engineers and provide the right environment to thrive, rise the ranks, and inspire others into following similar careers.",
                        "Continuing with Facebook as an example, just 17 percent of its workforce are female. This is far from an issue reserved to Facebook, however, and the situation among higher ranks is even more dire. Among the top 20 technology companies, only 11 percent of executive committee members are women."
                    }
                });

                context.SoftwareNews.Add(new SoftwareNew
                {
                    Title = "Google makes Cloud Speech API generally available to developers",
                    Subject = "By Developer Tech",
                    ContentBody = new[]
                    {
                        "Google is allowing third-party developers to access its speech recognition technology with the help of its Cloud Speech API, which has become generally available.",
                        "Cloud Speech, which allows developers to convert audio to text with a simple to use API, was introduced in open beta in summer 2016, and is built on the core technology that powers speech recognition for Google products, such as Google Assistant, Google Search, Google Now.",
                        "Google bettered the transcription accuracy for long-form audio and process data 3x faster than the initial version, thanks to the it received feedback from its customers and partners. In addition, more audio file formats are supported, including WAV, OPUS, and Speex. With context-aware recognition that orients listening according to the scenario, Google notes that early adopters have primarily used the API to control apps and devices with voice search, commands, and Interactive Voice Response (IVR). Cloud Speech can operate on a wide range of IoT devices, such as cars, TVs, speakers, phones and PCs.",
                        "The second frequent use case is with speech analytics that allows for “real-time insights from call centres.” Some businesses have used this in particular to monitor customer interactions and increase sales. For instance, Houston, Texas based InteractiveTel is using Cloud Speech API in solutions that track, monitor and report on dealer-customer interactions by telephone.",
                        "Pricing details for the Cloud Speech API are available on the Google Cloud Platform site."
                    }
                });

                context.SoftwareNews.Add(new SoftwareNew
                {
                    Title = "The software developers: What bespoke means to us",
                    Subject = "Design, Development Tools",
                    ContentBody = new[]
                    {
                        "In an ever-evolving market place, bespoke software development can be a tricky thing to pin down to a single definition. Rightly so, it encompasses different possibilities to different companies. For some clients, it’s producing a web based commercial application that interacts with customers, for others it’s producing an all-encompassing multi-platform CRM that serves all employees across business units.",
                        "For us, there are no limits as to what a bespoke software development could entail. Handcrafting each and every project with our client’s business in mind, enables our team to produce a software solution that is innovative, smart, flexible and absolutely unique.",
                        "We believe that bespoke software is a specialist craft, with many contributing dynamics. Here’s a little insight into the components that go into making a Decoded solution as special as it can be.",
                        "1. Uniquely Yours",
                        "Accomplishing an effective bespoke software solution requires an in-depth and precise understanding of your business. We invest great time in discovering all about your business objectives, operational strategy and commercial goals to ensure we provide a solution, which is targeted to your users and delivers marvelous results. Each project is approached with fresh thinking, and we ensure we deliver a tailor made development process, which is designed to suit your timeline, users, way of working, and business strategy.",
                        "While we pride ourselves on the excellence of our technical and creative talent, we wouldn’t be able to achieve the great things we do without developing finely tuned software strategies. A strategic approach, based on measurable objectives and long term growth, enables us to create solutions that have a significant impact on your business. That’s why we employ a collaborative approach from our very first conversation.",
                        "2. Tailor Made in Bournemouth",
                        "Decoded software is used around the world; at an international airport in Asia, in hotels throughout Europe, on ships in the Indian Ocean, and for aviation training in America. Yet we are super proud that everything is made in Bournemouth by our talented team of Software Architects, Developers, Testers, Project Managers and UI Designers. Every piece of UX component and line of code is created and managed at our Bournemouth office, ensuring the highest level of quality and attention to detail.",
                        "Being able to deliver a fully integrated development experience is all under one roof, enables our team to work closely together and for each aspect of the development to be handled with great care. It also helps to have such a glorious view of beautiful Bournemouth, which keeps us all bright and cheery.",
                        "3. Handpicked Technology",
                        "We're great advocates for the power bespoke software has to empower businesses to achieve more. None of which would be possible, without the help of our technical experts.",
                        "Intuitive and knowledgeable, our Software Architects present clients with the finest technology recommendations to compliment current and future business plans. We consider the system's users, the devices used, and which operating system will be most effective in achieving the overarching project objectives, leaving our client to then make an informed decision about the technology that best suits their business need.",
                        "Experienced in working across technologies, devices and operating systems, we build solutions which maximize the functionality of the chosen technology. We believe that with the right technology, even the most complex of challenges can be conquered.",
                        "4. The Art of Craftsmanship",
                        "We believe that usability in software is everything. From functionality and content to interaction and usability testing, the user is key to the development. Our user-centric approach aims to enhance the applicability and acceptance of the end product by placing the user at the heart of development. By analysing the explicit and implicit needs of the user in the discovery phase, the system is designed with the user in mind and development risk can be reduced.",
                        "Throughout our team of designers and developers, we are dedicated to crafting user experiences that are intuitive and enjoyable; focused on ensuring the tool is effective and engaging across all key users and environmental conditions.",
                        "5. Multi-Talented Experts",
                        "Some of us are analytical thinkers by nature; others walk on the creative side of life. As experts in our individual specialisms, we’re always learning from each other and celebrating the qualities that make us unique.",
                        "Truly multidisciplinary in our approach, our talented team are knowledgable and meticulous in their area of expertise. Problem solvers at heart, our Software Developers define and deliver architecture with precise consideration. Creative and perceptive, our UI Designers carefully craft user experiences that are uniquely intuitive. Excellent communicators, our Trainers build confidence with ease. Perfectionists by nature, our superb Project Management team know exactly how to get the best out of us all.",
                        "Throughout our teams, we are strategists and inventors who understand how to shape truly bespoke software solutions, no matter the size or complexity, which continue to add value every step of the way."
                    }
                });
            }
        }
    }
}