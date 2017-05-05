namespace PCMarket.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Cores;
    using Common;
    using Interfaces;
    using StorageDevices;

    public class Company : IModel<int>
    {
        private ICollection<Motherboard> motherboards;
        private ICollection<Processor> processors;
        private ICollection<VideoCard> videoCards;
        private ICollection<HardDrive> hardDrives;
        private ICollection<SolidStateDrive> solidStateDrives;
        private ICollection<BackupDevice> backupDevices;
        private ICollection<UsbFlash> usbFlashes;

        public Company()
        {
            this.motherboards = new HashSet<Motherboard>();
            this.processors = new HashSet<Processor>();
            this.videoCards = new HashSet<VideoCard>();
            this.hardDrives = new HashSet<HardDrive>();
            this.solidStateDrives = new HashSet<SolidStateDrive>();
            this.backupDevices = new HashSet<BackupDevice>();
            this.usbFlashes = new HashSet<UsbFlash>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [RegularExpression(Strings.UriPattern)]
        public string LogoImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Establish On")]
        public DateTime? EstablishOn { get; set; }

        public virtual ICollection<Motherboard> Motherboards
        {
            get { return this.motherboards; }
            set { this.motherboards = value; }
        }

        public virtual ICollection<Processor> Processors
        {
            get { return this.processors; }
            set { this.processors = value; }
        }

        public virtual ICollection<VideoCard> VideoCards
        {
            get { return this.videoCards; }
            set { this.videoCards = value; }
        }

        public virtual ICollection<HardDrive> HardDrives
        {
            get { return this.hardDrives; }
            set { this.hardDrives = value; }
        }

        public virtual ICollection<SolidStateDrive> SolidStateDrives
        {
            get { return this.solidStateDrives; }
            set { this.solidStateDrives = value; }
        }

        public virtual ICollection<BackupDevice> BackupDevices
        {
            get { return this.backupDevices; }
            set { this.backupDevices = value; }
        }

        public virtual ICollection<UsbFlash> UsbFlashes
        {
            get { return this.usbFlashes; }
            set { this.usbFlashes = value; }
        }
    }
}