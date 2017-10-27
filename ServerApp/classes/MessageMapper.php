<?php

class MessageMapper extends Mapper
{
    public function getMessageByReceiver($receivingChannel, $params)
    {
        $row_limit = array_key_exists('limit', $params) ? $params['limit'] : "50";
        $offset = array_key_exists('offset', $params) ? $params['offset'] : "0";
        $stmt = $this->db->prepare("SELECT * FROM message WHERE receivingChannel = :receivingChannel LIMIT $offset, $row_limit");
        $stmt->execute(["receivingChannel" => $receivingChannel]);
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new MessageEntity($row);
        }
        return $results;
    }

    public function save(MessageEntity $message)
    {
        $stmt = $this->db->prepare("INSERT INTO message(id, messageHeader, receivingChannel, timestamp, message) VALUES (:id, :messageHeader, :receivingChannel, :timestamp, :message)");
        $result = $stmt->execute([
            "id" => $message->getId(),
            "messageHeader" => $message->getMessageHeader(),
            "receivingChannel" => $message->getReceivingChannel(),
            "timestamp" => $message->getTimestamp(),
            "message" => $message->getMessage()
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }

    public function incrementProcessingCounter($id)
    {
        $stmt = $this->db->prepare("UPDATE message SET processingCounter = processingCounter + 1 WHERE id = :id");
        $result = $stmt->execute(["id" => $id]);
        if (!$result) {
            throw new Exception("Could not update record");
        }
    }

    public function delete($id)
    {
        $stmt = $this->db->prepare("DELETE FROM message WHERE id = :id");
        $result = $stmt->execute(["id" => $id]);
        if (!$result) {
            throw new Exception("Could not delete record");
        }
    }
}
