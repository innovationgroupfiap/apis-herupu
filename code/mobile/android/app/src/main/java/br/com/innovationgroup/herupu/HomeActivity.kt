package br.com.innovationgroup.herupu

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import android.widget.TextView
import br.com.innovationgroup.herupu.model.FeedbackAtividade
import br.com.innovationgroup.herupu.network.FeedbackApi
import br.com.innovationgroup.herupu.network.RetrofitHelper
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import okhttp3.Dispatcher

class HomeActivity : AppCompatActivity() {
    private lateinit var listaFeedbacks: MutableList<FeedbackAtividade>

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home)

        val btnQuest1 = findViewById<TextView>(R.id.btn_qst1)
        val btnQuest2 = findViewById<TextView>(R.id.btn_qst2)
        val btnQuest3 = findViewById<TextView>(R.id.btn_qst3)
        val btnQuest4 = findViewById<TextView>(R.id.btn_qst4)
        val btnQuest5 = findViewById<TextView>(R.id.btn_qst5)
        val btnQuest6 = findViewById<TextView>(R.id.btn_qst6)

        val btnNotas = findViewById<Button>(R.id.btn_notas)
        val viewNotas = findViewById<View>(R.id.view_notas)
        val btnHistorico = findViewById<Button>(R.id.btn_historico)
        val viewHistorico = findViewById<View>(R.id.view_historico)

        btnQuest1.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnQuest2.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnQuest3.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnQuest4.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnQuest5.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnQuest6.setOnClickListener {
            val i = Intent(this, AtividadeActivity::class.java)
            startActivity(i)
        }

        btnNotas.setOnClickListener {
            val i = Intent(this, NotasActivity::class.java)
            startActivity(i)
        }

        viewNotas.setOnClickListener {
            val i = Intent(this, NotasActivity::class.java)
            startActivity(i)
        }

        btnHistorico.setOnClickListener {
            val i = Intent(this, HistoricoActivity::class.java)
            startActivity(i)
        }

        viewHistorico.setOnClickListener {
            val i = Intent(this, HistoricoActivity::class.java)
            startActivity(i)
        }

    }

    private fun carregarDados(){
        CoroutineScope(Dispatchers.IO).launch() {
            try {
                val result = RetrofitHelper.getInstance().create(FeedbackApi::class.java).getFeedbacks()
                Log.i("EVENTO_API", "retornoApi: Sucesses: ${result.size} registros recuperados")
                listaFeedbacks = mutableListOf()
                result.forEach{listaFeedbacks.add((it))}

                withContext(Dispatchers.Main){

                }
            } catch (e: Exception) {
                Log.i("EVENTO_API", "retornoApi: + ${e.message}")
            }

        }
    }
}