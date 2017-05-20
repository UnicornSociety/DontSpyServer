<?php

class MessageMapper extends Mapper
{
    public function getMessageByReceiver($receiver, $params)
    {
        $row_limit = array_key_exists('limit', $params) ? $params['limit'] : "50";
        $offset = array_key_exists('offset', $params) ? $params['offset'] : "0";
        $stmt = $this->db->prepare("SELECT * FROM message WHERE receiver = :receiver LIMIT $offset, $row_limit");
        $stmt->execute(["receiver" => $receiver]);
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new MessageEntity($row);
        }
        return $results;
    }

    public function save(MessageEntity $message)
    {
        $stmt = $this->db->prepare("INSERT INTO message(message, timestamp, sender, receiver,keyNumber) VALUES (:message, :timestamp, :sender, :receiver, :keyNumber)");
        $result = $stmt->execute([
            "message" => $message->getMessage(),
            "timestamp" => $message->getTimestamp(),
            "sender" => $message->getSender(),
            "receiver" => $message->getReceiver(),
            "keyNumber" => $message->getKeyNumber()
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }
}
