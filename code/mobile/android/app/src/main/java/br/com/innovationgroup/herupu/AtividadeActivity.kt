package br.com.innovationgroup.herupu

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.view.Gravity
import android.widget.EditText
import android.widget.GridLayout
import android.widget.ImageView
import android.widget.LinearLayout
import androidx.appcompat.app.AppCompatActivity


class AtividadeActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_atividade)
        CarregarGrid()
        val imgSeta = findViewById<ImageView>(R.id.img_seta_volta)

        imgSeta.setOnClickListener{
            val i = Intent(this, HomeActivity::class.java)
            startActivity(i)
        }
    }

    fun CarregarGrid(){


        val btnsNames = ArrayList<String>();
        btnsNames.add("sapo");
        btnsNames.add("cachorro");
        btnsNames.add("tigre");
        btnsNames.add("girafa");

        val gridbtns = findViewById<GridLayout>(R.id.grid_atividade_item);

        val layoutLinearParams = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.WRAP_CONTENT,
            LinearLayout.LayoutParams.WRAP_CONTENT,
            5f
        )
        layoutLinearParams.gravity = Gravity.START
        layoutLinearParams.width = 450

        val layoutImage = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.MATCH_PARENT,
            LinearLayout.LayoutParams.MATCH_PARENT
        )

        layoutImage.height=400
        layoutImage.width = 400
        layoutImage.gravity = Gravity.CENTER

        val layoutText = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.WRAP_CONTENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )

        layoutText.height=400
        layoutText.width = 196
        layoutText.gravity = Gravity.CENTER

        btnsNames.forEach{
            val uri = "@drawable/" + it
            val imageResource = resources.getIdentifier(uri, null, packageName)
            val res = resources.getDrawable(imageResource)

            val layout = LinearLayout(this);
            layout.layoutParams = layoutLinearParams
            layout.orientation = LinearLayout.VERTICAL
            val image = ImageView(this)
            image.layoutParams = layoutImage
            image.setImageDrawable(res)
            layout.addView(image)

            val textView = EditText(this)
            textView.setTextSize(15F)
            textView.setHintTextColor(Color.parseColor("#44012c"))
            textView.setHint("Digite aqui")
            textView.background.setTint(Color.parseColor("#44012c"))
            layout.addView(textView)

            gridbtns.addView(layout)
        }
    }
}