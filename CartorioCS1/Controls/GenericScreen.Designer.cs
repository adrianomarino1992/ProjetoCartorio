namespace CartorioCS1.Controls
{
    partial class GenericScreen
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericScreen));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlBtnRemover = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBtnRemover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(21, 72);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(50, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(300, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(59, 16);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar : ";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(465, 19);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(331, 22);
            this.txtValue.TabIndex = 3;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContainer.Location = new System.Drawing.Point(24, 99);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(772, 375);
            this.pnlContainer.TabIndex = 6;
            // 
            // pnlBtnRemover
            // 
            this.pnlBtnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBtnRemover.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBtnRemover.Controls.Add(this.pictureBox6);
            this.pnlBtnRemover.Controls.Add(this.label7);
            this.pnlBtnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBtnRemover.Location = new System.Drawing.Point(633, 47);
            this.pnlBtnRemover.Name = "pnlBtnRemover";
            this.pnlBtnRemover.Size = new System.Drawing.Size(163, 43);
            this.pnlBtnRemover.TabIndex = 8;
            this.pnlBtnRemover.Click += new System.EventHandler(this.btnDeletar_Click);
            this.pnlBtnRemover.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.pnlBtnRemover.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(8, 6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.btnDeletar_Click);
            this.pictureBox6.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.pictureBox6.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Remover";
            this.label7.Click += new System.EventHandler(this.btnDeletar_Click);
            this.label7.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.label7.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(464, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 43);
            this.panel1.TabIndex = 9;
            this.panel1.Click += new System.EventHandler(this.btnSalvar_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.panel1.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnSalvar_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salvar";
            this.label1.Click += new System.EventHandler(this.btnSalvar_Click);
            this.label1.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.label1.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(295, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 43);
            this.panel2.TabIndex = 10;
            this.panel2.Click += new System.EventHandler(this.btnBuscar_Click);
            this.panel2.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.panel2.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnBuscar_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar";
            this.label2.Click += new System.EventHandler(this.btnBuscar_Click);
            this.label2.MouseEnter += new System.EventHandler(this.RefHoverStart);
            this.label2.MouseLeave += new System.EventHandler(this.RefHoverEnd);
            // 
            // GenericScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBtnRemover);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GenericScreen";
            this.Size = new System.Drawing.Size(820, 494);
            this.pnlBtnRemover.ResumeLayout(false);
            this.pnlBtnRemover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlBtnRemover;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}
