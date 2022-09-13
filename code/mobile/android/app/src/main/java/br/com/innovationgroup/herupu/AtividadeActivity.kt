package br.com.innovationgroup.herupu

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView

class AtividadeActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_atividade)

        val imgSeta = findViewById<ImageView>(R.id.img_seta_volta)

        imgSeta.setOnClickListener{
            val i = Intent(this, HomeActivity::class.java)
            startActivity(i)
        }
    }
}