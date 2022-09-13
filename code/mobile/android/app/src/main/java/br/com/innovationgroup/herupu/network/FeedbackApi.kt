package br.com.innovationgroup.herupu.network

import br.com.innovationgroup.herupu.model.FeedbackAtividade
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface FeedbackApi {

    @GET("api/Atividade/GetAll")
    suspend fun getFeedbacks():List<FeedbackAtividade>

    @POST("api/Atividade")
    suspend fun gravarFeedback(@Body feedbackAtividade: FeedbackAtividade)

}